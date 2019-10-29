using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Oap.Api.Rig.Profiles
{
    public class RigOapChecklistVerifierProfile : Profile
    {
        public RigOapChecklistVerifierProfile()
        {
            CreateMap<RigOapChecklistVerifier, RigOapChecklistVerifier>() 
                .ForMember(d => d.RigOapChecklist, op => op.Ignore());

        }
    }
}