using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class OapChecklistGroupProfile : Profile
    {
        public OapChecklistGroupProfile()
        {
            CreateMap<OapChecklistGroup, OapChecklistGroup>()
                .ForMember(d => d.OapGraphic, opt => opt.Ignore())
                .ForMember(d => d.OapChecklist, opt => opt.Ignore())
                .ForMember(d => d.SubGroups, opt => opt.Ignore())
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}