using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class OapChecklistAssetDataManagementProfile : Profile
    {
        public OapChecklistAssetDataManagementProfile()
        {
            CreateMap<OapAssetDataManagement, OapAssetDataManagement>()
                .ForMember(d => d.OapSubSystem, opt => opt.Ignore())
                //.ForMember(d => d.OapSystem, opt => opt.Ignore())
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());               
        }
    }
}