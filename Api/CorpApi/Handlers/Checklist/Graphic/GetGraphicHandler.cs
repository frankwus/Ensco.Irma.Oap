using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Graphic;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Graphic
{
    using Ensco.Irma.Extensions;

    public class GetGraphicHandler : IRequestHandler<GetGraphicRequest, OapGraphic>
    {
        private IOapGraphicService Service { get; set; }

        public GetGraphicHandler(IOapGraphicService graphicService)
        {
            Service = graphicService;
        }

        Task<OapGraphic> IRequestHandler<GetGraphicRequest, OapGraphic>.Handle(GetGraphicRequest request, CancellationToken cancellationToken)
        {
            var c = Service.Get(request.GraphicId);            
            return Task.FromResult(c);
        }
    }
}