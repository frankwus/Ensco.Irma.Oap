using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Graphic;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Graphic
{
    using Ensco.Irma.Extensions;

    public class GetAllGraphicHandler : IRequestHandler<GetAllGraphicRequest, IEnumerable<OapGraphic>>
    {
        private IOapGraphicService Service { get; set; }

        public GetAllGraphicHandler(IOapGraphicService graphicService)
        {
            Service = graphicService;
        }

        Task<IEnumerable<OapGraphic>> IRequestHandler<GetAllGraphicRequest, IEnumerable<OapGraphic>>.Handle(GetAllGraphicRequest request, CancellationToken cancellationToken)
        {
            var list = Service.GetAll(request.StartDate, request.EndDate);           

            return Task.FromResult(list);
        }
    }
}