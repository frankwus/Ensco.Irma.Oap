using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class OapChecklistQuestionRelatedQuestionMapProfile : Profile
    {
        public OapChecklistQuestionRelatedQuestionMapProfile()
        {
            CreateMap<OapCheckListQuestionRelatedQuestionMap, OapCheckListQuestionRelatedQuestionMap>()
                .ForMember(d => d.OapChecklistQuestionId, opt => opt.Ignore())                
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}