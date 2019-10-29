using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.RigApi.Profiles
{
    public class OapHierarchyProfile : Profile
    {
        public OapHierarchyProfile()
        {
            //Assumption is that Mapping is used for only Modification.  
            //if we are using Auto Mapper to Map on creation please comment the Created fields so they can be
            //properly mapped to destination object.
            //We are using the POCO objects that are created and used as domain models
            //for EF Code first as the default exchange interfaces over web API services rather that using 
            //separate DTO objects.
            CreateMap<OapHierarchy, OapHierarchy>()
                .ForMember(d => d.ChildrenHierarchies, opt => opt.Ignore())
                .ForMember(d => d.ParentHierarchy, opt => opt.Ignore())
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}