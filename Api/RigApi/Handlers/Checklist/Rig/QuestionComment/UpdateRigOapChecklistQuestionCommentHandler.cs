using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class UpdateRigOapChecklistQuestionCommentHandler : IRequestHandler<UpdateRigOapChecklistQuestionCommentRequest, RigOapChecklistQuestionComment>
    {
        private IRigOapChecklistQuestionCommentService RigOapChecklistQuestionCommentService { get; set; }
        public IMapper AutoMapper { get; }

        public UpdateRigOapChecklistQuestionCommentHandler(IRigOapChecklistQuestionCommentService rigOapChecklistQuestionCommentService, IMapper mapper)
        {
            RigOapChecklistQuestionCommentService = rigOapChecklistQuestionCommentService;
            AutoMapper = mapper;
        }

        Task<RigOapChecklistQuestionComment> IRequestHandler<UpdateRigOapChecklistQuestionCommentRequest, RigOapChecklistQuestionComment>.Handle(UpdateRigOapChecklistQuestionCommentRequest request, CancellationToken cancellationToken)
        {
            var existingCheckList = RigOapChecklistQuestionCommentService.Get(request.RigChecklistQuestionComment.Id);

            if (existingCheckList == null)
            {
                throw new ApplicationException($"UpdateRigOapChecklistHandler: RigChecklist with Id {request.RigChecklistQuestionComment.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            AutoMapper.Map(request.RigChecklistQuestionComment, existingCheckList);

            using (var ts = new TransactionScope())
            {
                RigOapChecklistQuestionCommentService.Update(existingCheckList);

                ts.Complete();
            }
             
            return Task.FromResult(existingCheckList);
        } 
    }
}