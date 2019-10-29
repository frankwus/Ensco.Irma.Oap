using System;
using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Linq;

namespace Ensco.Irma.Oap.Api.Rig.Profiles
{
    public class RigOapChecklistProfile : Profile
    {
        public RigOapChecklistProfile()
        {
            CreateMap<RigOapChecklist, RigOapChecklist>()
                .ForMember(d => d.OapChecklist, op => op.Ignore())
                .ForMember(d => d.Owner, op => op.Ignore())
                .ForMember(d => d.Questions, op => op.Ignore())
                .ForMember(d => d.Comments, op => op.Ignore())
                .ForMember(d => d.Assets, op => op.Ignore());
        }
    }
}