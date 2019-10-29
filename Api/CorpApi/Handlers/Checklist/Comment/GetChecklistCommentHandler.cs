using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Comment;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Comment
{
    using Ensco.Irma.Extensions;

    public class GetChecklistCommentHandler : IRequestHandler<GetChecklistCommentRequest, OapChecklistComment>
    {
        private IOapChecklistCommentService Service { get; set; }

        public GetChecklistCommentHandler(IOapChecklistCommentService ChecklistCommentService)
        {
            Service = ChecklistCommentService;
        }

        Task<OapChecklistComment> IRequestHandler<GetChecklistCommentRequest, OapChecklistComment>.Handle(GetChecklistCommentRequest request, CancellationToken cancellationToken)
        {
            var c = Service.Get(request.ChecklistCommentId);             

            return Task.FromResult(c);
        }
    }
}