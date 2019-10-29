using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Interfaces.Services.Workflow;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using Ensco.Irma.Services.Workflow.Designers;
using MediatR;
using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using workflow = Ensco.Irma.Models.Domain.Workflow;
using System.Linq;
using System.Collections.Generic;
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Oap.Api.Common.Mapper;
using Ensco.Irma.Models.Domain.Workflow;
using Ensco.Irma.Oap.Api.Rig.Extensions;
using System.Configuration;
using Ensco.Irma.Extensions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class UpdateRigOapChecklistHandler : IRequestHandler<UpdateRigOapChecklistRequest, RigOapChecklist>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }
        public IRigOapChecklistQuestionNoAnswerCommentService ChecklistQuestionNoAnswerCommentService { get; }
        public IMapper Mapper { get; } 

        public UpdateRigOapChecklistHandler(IRigOapChecklistService rigOapChecklistService,IRigOapChecklistQuestionNoAnswerCommentService checklistQuestionNoAnswerCommentService, IMapper mapper)
        {
            RigOapChecklistService = rigOapChecklistService;
            ChecklistQuestionNoAnswerCommentService = checklistQuestionNoAnswerCommentService;
            Mapper = mapper;
        }

        Task<RigOapChecklist> IRequestHandler<UpdateRigOapChecklistRequest, RigOapChecklist>.Handle(UpdateRigOapChecklistRequest request, CancellationToken cancellationToken)
        {
            var existingCheckList = RigOapChecklistService.GetCompleteChecklist(request.Checklist.Id);

            if (existingCheckList == null)
            {
                throw new ApplicationException($"UpdateRigOapChecklistHandler: RigChecklist with Id {request.Checklist.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.Checklist, existingCheckList);

            //To handle the case when update is done in the DashBoard
            if (request.Checklist.Questions != null)
            {
                Mapper.AddOrUpdate<RigOapChecklistQuestion, Guid>(request.Checklist.Questions, existingCheckList.Questions, (dl, sq) => dl.SingleOrDefault(i => i.OapChecklistQuestionId == sq.OapChecklistQuestionId));

                foreach (var sq in request.Checklist.Questions)
                {
                    var dq = existingCheckList.Questions.SingleOrDefault(q => q.OapChecklistQuestionId == sq.OapChecklistQuestionId);
                    if (dq != null)
                    {
                        Mapper.AddOrUpdate<RigOapChecklistQuestionAnswer, Guid>(sq.Answers, dq.Answers, (dl, sqa) => dl.SingleOrDefault(i => i.RigOapChecklistQuestionId == sqa.RigOapChecklistQuestionId && i.Ordinal == sqa.Ordinal));

                        //if (sq.NoAnswerComment != null && dq.NoAnswerComment == null) //Add
                        //{
                        //    sq.NoAnswerComment.Id = sq.Id;
                        //    var id = ChecklistQuestionNoAnswerCommentService.Add(sq.NoAnswerComment);
                        //}
                        //else if (sq.NoAnswerComment == null && dq.NoAnswerComment != null)
                        //{
                        //    ChecklistQuestionNoAnswerCommentService.Delete(dq.NoAnswerComment);
                        //}
                        //else if (sq.NoAnswerComment != null && dq.NoAnswerComment != null)
                        //{

                        //    //var saveFile = !string.IsNullOrEmpty(sq.NoAnswerComment.FileName) && string.IsNullOrEmpty(dq.NoAnswerComment.FileName);
                        //    //if (saveFile)
                        //    //{
                        //    //    var imageLocation = $"{ConfigurationManager.AppSettings["uploadfilepath"]}\\{sq.NoAnswerComment.FileName}";
                        //    //    sq.NoAnswerComment.FileStream?.Save(imageLocation);
                        //    //}

                        //    Mapper.Map(sq.NoAnswerComment, dq.NoAnswerComment);

                        //    ChecklistQuestionNoAnswerCommentService.Update(sq.NoAnswerComment);
                        //}

                    }

                }
            }
            //To handle the case when update is done in the DashBoard
            if (request.Checklist.Comments != null)
            {
                Mapper.AddOrUpdate<RigOapChecklistComment, Guid>(request.Checklist.Comments, existingCheckList.Comments, (dl, sq) => dl.SingleOrDefault(i => i.OapChecklistCommentId == sq.OapChecklistCommentId));

            }

            var rigOapChecklist = request.Checklist;

            using (var ts = new TransactionScope())
            {
                RigOapChecklistService.Update(existingCheckList);

                ts.Complete();
            }
             
            return Task.FromResult(RigOapChecklistService.GetCompleteChecklist(existingCheckList.Id));
        } 
    }
}