using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Graphic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Graphic
{
    using Ensco.Irma.Extensions;
    using global::System.Configuration;

    public class AddGraphicHandler : IRequestHandler<AddGraphicRequest, OapGraphic>
    {
        private IOapGraphicService GraphicService { get; set; }

        public AddGraphicHandler(IOapGraphicService graphicService)
        {
            GraphicService = graphicService;
        }

        Task<OapGraphic> IRequestHandler<AddGraphicRequest, OapGraphic>.Handle(AddGraphicRequest request, CancellationToken cancellationToken)
        {
            var existingGraphic = GraphicService.GetByName(request.Graphic.Name);
            if (existingGraphic  != null)
            {
                return Task.FromResult(existingGraphic);
            }

            int newGraphicId = 0;
            using (var ts = new TransactionScope())
            {   
                //if (request.Graphic.StartDateTime.IsDefaultMin() || request.Graphic.StartDateTime.IsDefaultMax())
                //{
                //    request.Graphic.StartDateTime = DateTime.Now;
                //}

                //if (request.Graphic.EndDateTime.IsDefaultMin())
                //{
                //    request.Graphic.EndDateTime = DateTime.MaxValue;
                //}

                newGraphicId = GraphicService.Add(request.Graphic); 
                
                ts.Complete();
            }
            return Task.FromResult(GraphicService.Get(newGraphicId));
        }

         
    }
}