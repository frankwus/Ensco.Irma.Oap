using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Oap.Api.Rig.Profiles
{
    public class RigOapChecklistAssessorProfile : Profile
    {
        public RigOapChecklistAssessorProfile()
        {
            CreateMap<RigOapChecklistAssessor, RigOapChecklistAssessor>() 
                .ForMember(d => d.RigOapChecklist, op => op.Ignore());

        }
    }
}