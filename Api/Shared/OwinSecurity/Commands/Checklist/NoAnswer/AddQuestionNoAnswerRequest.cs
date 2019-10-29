using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.NoAnswer
{
    public class AddQuestionNoAnswerRequest : IRequest<RigOapChecklistQuestionNoAnswerComment>
    {
        public AddQuestionNoAnswerRequest(int oapChecklistId, int oapChecklistQuestionId, Guid rigOapChecklistId, int userId)
        {
            OapChecklistId = oapChecklistId;
            OapChecklistQuestionId = oapChecklistQuestionId;
            RigOapChecklistId = rigOapChecklistId;
            StartedBy = userId;
        }

        public int OapChecklistQuestionId { get; }
        public Guid RigOapChecklistId { get; }                
        public string Comment { get; }
        public int StartedBy { get; }
        public int OapChecklistId { get; }
    }
}
