using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap
{
    public class GetAllTagMapsForQuestionRequest : IRequest<IEnumerable<OapChecklistQuestionTagMap>>
    { 
        public GetAllTagMapsForQuestionRequest(int questionId)
        {
            QuestionId = questionId;
        }

        public int QuestionId { get; }
    }
}