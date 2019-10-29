using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question
{
    public class GetAllChecklistQuestionRequest : IRequest<IEnumerable<OapChecklistQuestion>>
    { 
        public GetAllChecklistQuestionRequest(int checklistId)
        {
            ChecklistId = checklistId;
        }

        public int ChecklistId { get; set; }
    }
}