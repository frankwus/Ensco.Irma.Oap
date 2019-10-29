using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Oap.Api.Corp.Profiles
{
    public class OapChecklistTopicProfile : Profile
    {
        public OapChecklistTopicProfile()
        {
            CreateMap<OapChecklistTopic, OapChecklistTopic>()
                .ForMember(d => d.OapChecklistGroup, opt => opt.Ignore())
                .ForMember(d => d.OapChecklistSubGroup, opt => opt.Ignore())
                .ForMember(d => d.Questions, opt => opt.Ignore())
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}