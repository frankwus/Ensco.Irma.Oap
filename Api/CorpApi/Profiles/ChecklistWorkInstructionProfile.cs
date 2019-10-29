using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class ChecklistWorkInstructionProfile : Profile
    {
        public ChecklistWorkInstructionProfile()
        {
            CreateMap<OapChecklistWorkInstruction, OapChecklistWorkInstruction>()
                .ForMember(d => d.OapWorkInstruction, opt => opt.Ignore())
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());      
        }
    }
}