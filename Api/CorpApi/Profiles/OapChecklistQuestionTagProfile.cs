using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class OapChecklistQuestionTagProfile : Profile
    {
        public OapChecklistQuestionTagProfile()
        {
            CreateMap<OapChecklistQuestionTag, OapChecklistQuestionTag>()
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}