using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Oap.Api.Rig.Profiles
{
    public class RigOapChecklistQuestionNoAnswerCommentProfile : Profile
    {
        public RigOapChecklistQuestionNoAnswerCommentProfile()
        {
            CreateMap<RigOapChecklistQuestionNoAnswerComment, RigOapChecklistQuestionNoAnswerComment>()
                //.ForMember(d => d.FileStream, op => op.Ignore())
                .ForMember(d => d.OapChecklistQuestionId, op => op.Ignore());
        }
    }
}