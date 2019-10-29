using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Oap.Api.Corp.Profiles
{
    public class OapProtocolQuestionHeaderProfile:Profile
    {
        public OapProtocolQuestionHeaderProfile()
        {
            CreateMap<OapProtocolQuestionHeader, OapProtocolQuestionHeader>()
                .ForMember(d => d.OapChecklistQuestion, opt => opt.Ignore())
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}