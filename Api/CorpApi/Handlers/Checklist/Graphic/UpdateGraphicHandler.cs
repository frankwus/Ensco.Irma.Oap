using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
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

    public class UpdateGraphicHandler : IRequestHandler<UpdateGraphicRequest, bool>
    {
        private IOapGraphicService GraphicService { get; set; }
         

        private IMapper Mapper { get; set;  }

        public UpdateGraphicHandler(IOapGraphicService graphicService, IMapper mapper)
        {
            GraphicService = graphicService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateGraphicRequest, bool>.Handle(UpdateGraphicRequest request, CancellationToken cancellationToken)
        {
            var existingGraphic = GraphicService.Get(request.Graphic.Id);

            if (existingGraphic == null)
            {
                throw new ApplicationException($"UpdateGraphicHandler: Graphic with Id {request.Graphic.Id} does not exist.");
            }

            //var deleteImage = (request.Graphic.Image == null) && !string.IsNullOrEmpty(existingGraphic.ImageLocation);

            //var saveImage = (request.Graphic.Image != null) && string.IsNullOrEmpty(existingGraphic.ImageLocation);

            //AutoMapper to Map the fields 
            Mapper.Map(request.Graphic, existingGraphic);

            //if (saveImage) //Image Added so Save the image.
            //{
            //    var imageLocation = $"{ConfigurationManager.AppSettings["uploadfilepath"]}\\{request.Graphic.Name.Replace(' ', '_')}.png";
            //    existingGraphic.ImageLocation = imageLocation;
            //    request.Graphic.Image.Save(imageLocation);
            //}

            //if (deleteImage)
            //{
            //    existingGraphic.ImageLocation = string.Empty;
            //}

            using (var ts = new TransactionScope())
            {
                var updatedGraphic = GraphicService.Update(existingGraphic);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}