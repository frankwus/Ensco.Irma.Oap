using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Data.Repositories.Irma;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Oap.Checklist; 
using System.Collections.Generic;
using System.Linq;

namespace Ensco.Irma.Services.Oap
{
    
    public class OapAuditProtocolMapService : EntityIdService<IrmaOapDbContext, IOapAuditProtocolMapRepository, OapAuditProtocol, int> , IOapAuditProtocolMapService
    {
        public IPeopleRepository PeopleRepository { get; }
        public IPobPersonnelRepository PobPersonnelRepository { get; }

        public OapAuditProtocolMapService(IOapAuditProtocolMapRepository repository,
            IPeopleRepository peopleRepository, 
            IPobPersonnelRepository pobPersonnelRepository) : base(repository)
        {
            PeopleRepository = peopleRepository;
            PobPersonnelRepository = pobPersonnelRepository;
        }

        //Get protocols from mapping table
        public IEnumerable<RigOapChecklist> GetProtocolsByAuditId(int auditId)
        {
            var protocols = Repository.GetProtocolsByAuditId(auditId);

            foreach(var p in protocols)
            {
                p.Owner = PeopleRepository.Get(p.OwnerId);

                if ((p.Assessors != null) && p.Assessors.Any())
                {
                    foreach (var a in p.Assessors)
                    {
                        a.TourId = PobPersonnelRepository.GetTourId(a.UserId);
                        a.User = PeopleRepository.Get(a.UserId);
                    }
                }
            }                        

            return protocols;
        }       
    }
}
