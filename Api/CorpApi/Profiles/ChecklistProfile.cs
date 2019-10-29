using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Api.Corp.Profiles
{
    public class ChecklistProfile: Profile
    {
        public ChecklistProfile()
        {
            CreateMap<OapChecklist, OapChecklist>()
                .ForMember(d => d.OapFrequencyType, opt => opt.Ignore())
                .ForMember(d => d.OapProtocolFormType, opt => opt.Ignore())
                .ForMember(d => d.OapSubType, opt => opt.Ignore())
                .ForMember(d => d.OapType, opt => opt.Ignore())
                .ForMember(d => d.Groups, opt => opt.Ignore())
                .ForMember(d => d.Comments, opt => opt.Ignore()) 
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}