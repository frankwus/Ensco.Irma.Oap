using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class OapChecklistQuestionProfile : Profile
    {
        public OapChecklistQuestionProfile()
        {
            CreateMap<OapChecklistQuestion, OapChecklistQuestion>()
                .ForMember(d => d.OapChecklistTopic, opt => opt.Ignore())
                .ForMember(d => d.ProtocolQuestionHeader, opt => opt.Ignore())
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore())
                .ForMember(d => d.OapChecklistQuestionTagMaps , opt => opt.Ignore());
        }
    }
}