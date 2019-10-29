using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using Ensco.Irma.Oap.Api.Common.Mapper;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits.AuditProtocol
{
    public class UpdateAuditProtocolHandler : IRequestHandler<UpdateAuditProtocolRequest, RigOapChecklist>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }
        public IRigOapChecklistQuestionNoAnswerCommentService ChecklistQuestionNoAnswerCommentService { get; }
        public IMapper Mapper { get; } 

        public UpdateAuditProtocolHandler(IRigOapChecklistService rigOapChecklistService,IRigOapChecklistQuestionNoAnswerCommentService checklistQuestionNoAnswerCommentService, IMapper mapper)
        {
            RigOapChecklistService = rigOapChecklistService;
            ChecklistQuestionNoAnswerCommentService = checklistQuestionNoAnswerCommentService;
            Mapper = mapper;
        }

        Task<RigOapChecklist> IRequestHandler<UpdateAuditProtocolRequest, RigOapChecklist>.Handle(UpdateAuditProtocolRequest request, CancellationToken cancellationToken)
        {
            var existingCheckList = RigOapChecklistService.GetCompleteChecklist(request.Protocol.Id);

            if (existingCheckList == null)
            {
                throw new ApplicationException($"UpdateRigOapChecklistHandler: RigChecklist with Id {request.Protocol.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.Protocol, existingCheckList);

            //To handle the case when update is done in the DashBoard
            if (request.Protocol.Questions != null)
            {
                Mapper.AddOrUpdate<RigOapChecklistQuestion, Guid>(request.Protocol.Questions, existingCheckList.Questions, (dl, sq) => dl.SingleOrDefault(i => i.OapChecklistQuestionId == sq.OapChecklistQuestionId));

                foreach (var sq in request.Protocol.Questions)
                {
                    var dq = existingCheckList.Questions.SingleOrDefault(q => q.OapChecklistQuestionId == sq.OapChecklistQuestionId);
                    if (dq != null)
                    {
                        Mapper.AddOrUpdate<RigOapChecklistQuestionAnswer, Guid>(sq.Answers, dq.Answers, (dl, sqa) => dl.SingleOrDefault(i => i.RigOapChecklistQuestionId == sqa.RigOapChecklistQuestionId && i.Ordinal == sqa.Ordinal));
                    }
                }
            }
            //To handle the case when update is done in the DashBoard
            if (request.Protocol.Comments != null)
            {
                Mapper.AddOrUpdate<RigOapChecklistComment, Guid>(request.Protocol.Comments, existingCheckList.Comments, (dl, sq) => dl.SingleOrDefault(i => i.OapChecklistCommentId == sq.OapChecklistCommentId));

            }

            var rigOapChecklist = request.Protocol;

            using (var ts = new TransactionScope())
            {
                RigOapChecklistService.Update(existingCheckList);

                ts.Complete();
            }
             
            return Task.FromResult(RigOapChecklistService.GetCompleteChecklist(existingCheckList.Id));
        } 
    }
}