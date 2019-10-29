using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Oap.Api.Corp.Profiles
{
    public class RigOapChecklistQuestionAnswerProfile : Profile
    {
        public RigOapChecklistQuestionAnswerProfile()
        {
            CreateMap<RigOapChecklistQuestionAnswer, RigOapChecklistQuestionAnswer>()
               .ForMember(d => d.RigOapChecklistQuestion, op => op.Ignore());
        }
    }
}