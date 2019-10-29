using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Comment
{
    public class GetChecklistCommentRequest : IRequest<OapChecklistComment>
    { 
        public GetChecklistCommentRequest(int commentId)
        {
            ChecklistCommentId = commentId;
        }

        public int ChecklistCommentId {get; set;}
    }
}