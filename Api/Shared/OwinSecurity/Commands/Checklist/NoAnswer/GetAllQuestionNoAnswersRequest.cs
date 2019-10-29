using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist
{
    public class GetAllQuestionNoAnswersRequest : IRequest<IEnumerable<RigOapChecklistQuestionNoAnswerComment>>
    {
        public GetAllQuestionNoAnswersRequest(int oapChecklistId, int oapChecklistQuestionId)
        {
            OapChecklistId = oapChecklistId;
            OapChecklistQuestionId = oapChecklistQuestionId;
        }

        public int OapChecklistId { get; }
        public int OapChecklistQuestionId { get; }
    }
}
