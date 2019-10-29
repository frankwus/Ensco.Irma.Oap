using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class OapChecklistQuestionTagMapProfile : Profile
    {
        public OapChecklistQuestionTagMapProfile()
        {
            CreateMap<OapChecklistQuestionTagMap, OapChecklistQuestionTagMap>()
                .ForMember(d => d.OapChecklistQuestionTag, opt => opt.Ignore())
                .ForMember(d => d.OapChecklistQuestion, opt => opt.Ignore())
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}