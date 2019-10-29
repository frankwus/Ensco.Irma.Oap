using AutoMapper;
using Ensco.Irma.Models.Domain.Oap.Audit;

namespace Ensco.Irma.Oap.Api.Corp.Profiles
{
    public class OapAuditProfile : Profile
    {
        public OapAuditProfile()
        {
            CreateMap<OapAudit, OapAudit>()
                .ForMember(d => d.CreatedDateTime, opt => opt.Ignore())
                 .ForMember(d => d.StartDateTime, opt => opt.Ignore())
                  .ForMember(d => d.EndDateTime, opt => opt.Ignore())
                    .ForMember(d => d.RigId, opt => opt.Ignore())
                  .ForMember(d => d.OapAuditProtocols, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore());
        }
    }
}