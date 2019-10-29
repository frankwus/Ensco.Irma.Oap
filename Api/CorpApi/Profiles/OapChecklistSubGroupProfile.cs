using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class OapChecklistSubGroupProfile : Profile
    {
        public OapChecklistSubGroupProfile()
        {
            CreateMap<OapChecklistSubGroup, OapChecklistSubGroup>()                
                .ForMember(d => d.OapChecklistGroup, opt => opt.Ignore())
                .ForMember(d => d.Topics, opt => opt.Ignore())
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}