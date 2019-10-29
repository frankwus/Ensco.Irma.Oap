using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Graphic
{
    public class AddGraphicRequest : IRequest<OapGraphic>
    {
        public AddGraphicRequest(OapGraphic graphic)
        {
            Graphic = graphic;
        }

        public OapGraphic Graphic { get;  }
    }
}