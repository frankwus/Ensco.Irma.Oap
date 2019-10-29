using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Oap.Api.Rig.Profiles
{
    public class RigOapChecklistCommentProfile : Profile
    {
        public RigOapChecklistCommentProfile()
        {
            CreateMap<RigOapChecklistComment, RigOapChecklistComment>()
                .ForMember(d => d.RigOapChecklist, op => op.Ignore()) 
                .ForMember(d => d.OapChecklistComment, op => op.Ignore());
        }
    }
}