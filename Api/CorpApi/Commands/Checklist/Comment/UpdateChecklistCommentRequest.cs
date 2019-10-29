using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Comment
{
    public class UpdateChecklistCommentRequest : IRequest<bool>
    {
        public UpdateChecklistCommentRequest(OapChecklistComment comment)
        {
            ChecklistComment = comment;
        }

        public OapChecklistComment ChecklistComment { get;  }
    }
}