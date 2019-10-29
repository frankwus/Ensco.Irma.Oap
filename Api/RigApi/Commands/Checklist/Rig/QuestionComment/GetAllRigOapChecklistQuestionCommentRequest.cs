using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment
{
    public class GetAllRigOapChecklistQuestionCommentRequest : IRequest<IEnumerable<RigOapChecklistQuestionComment>>
    { 
        public GetAllRigOapChecklistQuestionCommentRequest()
        { 
        }
         
    }
}