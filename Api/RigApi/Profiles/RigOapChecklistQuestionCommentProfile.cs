using System;
using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Linq;

namespace Ensco.Irma.Oap.Api.Rig.Profiles
{
    public class RigOapChecklistQuestionCommentProfile : Profile
    {
        public RigOapChecklistQuestionCommentProfile()
        {
            CreateMap<RigOapChecklistQuestionComment, RigOapChecklistQuestionComment>()
                .ForMember(d => d.RigOapChecklistQuestion, op => op.Ignore());
        }

       
    }
}