using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class OapFrequencyTypeProfile : Profile
    {
        public OapFrequencyTypeProfile()
        {
            CreateMap<OapFrequencyType, OapFrequencyType>()
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}