using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Oap.Api.Rig.Profiles
{
    public class RigOapChecklistGroupAssetProfile : Profile
    {
        public RigOapChecklistGroupAssetProfile()
        {
            CreateMap<RigOapChecklistGroupAsset, RigOapChecklistGroupAsset>()
                .ForMember(d => d.RigOapChecklist, op => op.Ignore());

        }
    }
}