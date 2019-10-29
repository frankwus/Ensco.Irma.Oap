using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;


namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits
{
    public class UpdateOapAuditHandler: IRequestHandler<UpdateOapAuditRequest, bool>
    {

        private IOapAuditService AuditService { get; set; }


        private IMapper Mapper { get; set; }

        public UpdateOapAuditHandler(IOapAuditService auditService, IMapper mapper)
        {
            AuditService = auditService;
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateOapAuditRequest, bool>.Handle(UpdateOapAuditRequest request, CancellationToken cancellationToken)
        {
            OapAudit oAudit = AuditService.Get(request.Audit.Id);
            
            

            if (oAudit == null)
            {
                throw new ApplicationException($"UpdateFrequencyTypeHandler: FrequencyType with Id {request.Audit.Id} does not exist.");
            }



            //AutoMapper to Map the fields 
            Mapper.Map(request.Audit, oAudit);

            using (var ts = new TransactionScope())
            {
                var updatedAudit = AuditService.Update(oAudit);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}