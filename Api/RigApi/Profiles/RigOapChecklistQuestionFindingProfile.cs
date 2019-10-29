using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Oap.Api.Rig.Profiles
{
    public class RigOapChecklistQuestionFindingProfile : Profile
    {
        public RigOapChecklistQuestionFindingProfile()
        {
            CreateMap<RigOapChecklistQuestionFinding, RigOapChecklistQuestionFinding>()
                .ForMember(d => d.RigOapChecklistQuestion, op => op.Ignore())
                .ForMember(d => d.FindingSubType, op => op.Ignore())
                .ForMember(d => d.FindingType, op => op.Ignore());
        }
    }
}