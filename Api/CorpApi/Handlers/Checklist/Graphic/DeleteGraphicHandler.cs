using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Graphic;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Graphic
{
    public class DeleteGraphicHandler : IRequestHandler<DeleteGraphicRequest, bool>
    {
        private IOapGraphicService GraphicService { get; set; }

        public DeleteGraphicHandler(IOapGraphicService graphicService)
        {
            GraphicService = graphicService;
        }

        Task<bool> IRequestHandler<DeleteGraphicRequest, bool>.Handle(DeleteGraphicRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var Graphic = GraphicService.Get(request.GraphicId);
                 
                GraphicService.Delete(Graphic);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}