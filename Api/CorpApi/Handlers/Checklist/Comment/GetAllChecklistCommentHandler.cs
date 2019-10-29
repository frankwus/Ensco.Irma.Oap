using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Comment;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Comment
{
    using Ensco.Irma.Extensions;

    public class GetAllChecklistCommentHandler : IRequestHandler<GetAllChecklistCommentRequest, IEnumerable<OapChecklistComment>>
    {
        private IOapChecklistCommentService Service { get; set; }

        public GetAllChecklistCommentHandler(IOapChecklistCommentService ChecklistCommentService)
        {
            Service = ChecklistCommentService;
        }

        Task<IEnumerable<OapChecklistComment>> IRequestHandler<GetAllChecklistCommentRequest, IEnumerable<OapChecklistComment>>.Handle(GetAllChecklistCommentRequest request, CancellationToken cancellationToken)
        {
            var list = Service.GetAll(request.StartDate, request.EndDate);            

            return Task.FromResult(list);
        }
    }
}