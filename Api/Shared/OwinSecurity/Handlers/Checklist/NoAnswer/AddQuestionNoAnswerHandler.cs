using System.Threading;
using System.Threading.Tasks;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.NoAnswer;
using MediatR;
using System;
using Ensco.Irma.Interfaces.Services.Oap;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.NoAnswer
{
    public class AddQuestionNoAnswerHandler : IRequestHandler<AddQuestionNoAnswerRequest, RigOapChecklistQuestionNoAnswerComment>
    {
        private readonly IRigOapChecklistQuestionNoAnswerCommentService service;

        public AddQuestionNoAnswerHandler(IRigOapChecklistQuestionNoAnswerCommentService service)
        {
            this.service = service;
        }
        public Task<RigOapChecklistQuestionNoAnswerComment> Handle(AddQuestionNoAnswerRequest request, CancellationToken cancellationToken)
        {
            RigOapChecklistQuestionNoAnswerComment model = new RigOapChecklistQuestionNoAnswerComment()
            {
                Id = Guid.NewGuid(),
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                StartCommentBy = request.StartedBy,
                OapChecklistQuestionId = request.OapChecklistQuestionId,
                SourceRigOapChecklistId = request.RigOapChecklistId,
                OapChecklistId = request.OapChecklistId,
                StartDateTime = DateTime.UtcNow
            };
            
            Guid newModelGuid = service.Add(model);
            var result = service.Get(newModelGuid);

            return Task.FromResult(result);
        }
    }
}
