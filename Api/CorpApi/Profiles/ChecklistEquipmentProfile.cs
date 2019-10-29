using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class ChecklistEquipmentProfile : Profile
    {
        public ChecklistEquipmentProfile()
        {
            CreateMap<OapChecklistEquipment, OapChecklistEquipment>()
                .ForMember(d => d.OapEquipment, opt => opt.Ignore())
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());            
        }
    }
}