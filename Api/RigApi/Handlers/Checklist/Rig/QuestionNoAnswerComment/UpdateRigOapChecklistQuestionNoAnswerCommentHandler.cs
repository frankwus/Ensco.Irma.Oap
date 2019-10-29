using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment;
using System.Configuration;
using Ensco.Irma.Extensions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class UpdateRigOapChecklistQuestionNoAnswerCommentHandler : IRequestHandler<UpdateRigOapChecklistQuestionNoAnswerCommentRequest, RigOapChecklistQuestionNoAnswerComment>
    {
        private IRigOapChecklistQuestionNoAnswerCommentService RigOapChecklistQuestionNoAnswerCommentService { get; set; }
        public IMapper AutoMapper { get; }

        public UpdateRigOapChecklistQuestionNoAnswerCommentHandler(IRigOapChecklistQuestionNoAnswerCommentService rigOapChecklistQuestionNoAnswerCommentService, IMapper mapper)
        {
            RigOapChecklistQuestionNoAnswerCommentService = rigOapChecklistQuestionNoAnswerCommentService;
            AutoMapper = mapper;
        }

        Task<RigOapChecklistQuestionNoAnswerComment> IRequestHandler<UpdateRigOapChecklistQuestionNoAnswerCommentRequest, RigOapChecklistQuestionNoAnswerComment>.Handle(UpdateRigOapChecklistQuestionNoAnswerCommentRequest request, CancellationToken cancellationToken)
        {
            var existingNoAnswer = RigOapChecklistQuestionNoAnswerCommentService.Get(request.RigChecklistQuestionNoAnswerComment.Id);

            if (existingNoAnswer == null)
            {
                throw new ApplicationException($"UpdateRigOapChecklistHandler: RigChecklist with Id {request.RigChecklistQuestionNoAnswerComment.Id} does not exist.");
            }

            //var deleteFile = (request.RigChecklistQuestionNoAnswerComment.FileStream == null) && !string.IsNullOrEmpty(existingNoAnswer.FileName);

            //var saveFile= (request.RigChecklistQuestionNoAnswerComment.FileStream != null) && string.IsNullOrEmpty(existingNoAnswer.FileName);

            //AutoMapper to Map the fields 
            AutoMapper.Map(request.RigChecklistQuestionNoAnswerComment, existingNoAnswer);

            //if (saveFile)  
            //{
            //    var fileLocation = $"{ConfigurationManager.AppSettings["uploadfilepath"]}\\{request.RigChecklistQuestionNoAnswerComment.FileName}";
            //    existingNoAnswer.FileName = fileLocation;
            //    request.RigChecklistQuestionNoAnswerComment.FileStream.Save(fileLocation);
            //}

            //if (deleteFile)
            //{
            //    existingNoAnswer.FileName = string.Empty;
            //} 

            using (var ts = new TransactionScope())
            {
                RigOapChecklistQuestionNoAnswerCommentService.Update(existingNoAnswer);

                ts.Complete();
            }
             
            return Task.FromResult(existingNoAnswer);
        } 
    }
}