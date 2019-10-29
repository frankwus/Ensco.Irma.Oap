using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Comment
{
    public class AddChecklistCommentRequest : IRequest<OapChecklistComment>
    {
        public AddChecklistCommentRequest(OapChecklistComment comment)
        {
            ChecklistComment = comment;
        }

        public OapChecklistComment ChecklistComment { get;  }
    }
}