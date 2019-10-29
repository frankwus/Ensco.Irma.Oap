using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionRelatedQuestionMap
{
    public class GetAllQuestionRelatedQuestionMapRequest : IRequest<IEnumerable<OapChecklistQuestion>>
    { 
        public GetAllQuestionRelatedQuestionMapRequest(int questionId)
        {
            QuestionId = questionId;
        }

        public int QuestionId { get; }
    }
}