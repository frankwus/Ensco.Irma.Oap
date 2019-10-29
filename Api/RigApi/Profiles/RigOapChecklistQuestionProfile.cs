using System;
using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Linq;

namespace Ensco.Irma.Oap.Api.Rig.Profiles
{
    public class RigOapChecklistQuestionProfile : Profile
    {
        public RigOapChecklistQuestionProfile()
        {
            CreateMap<RigOapChecklistQuestion, RigOapChecklistQuestion>()
                .ForMember(d => d.OapChecklistQuestion, op => op.Ignore())
                .ForMember(d => d.RigOapChecklist, op => op.Ignore())
                .ForMember(d => d.Answers, op => op.Ignore());
                //.ForMember(d => d.NoAnswerComment, op => op.Ignore());
        }
    }
}