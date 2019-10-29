using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapWorkInstructionService : EntityIdService<IrmaOapDbContext, IOapWorkInstructionRepository, OapWorkInstruction, int>, IOapWorkInstructionService
    {
        public OapWorkInstructionService(IOapWorkInstructionRepository workInstructionRepository) : base(workInstructionRepository)
        {

        }
    }
}
