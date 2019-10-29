using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Graphic
{
    public class GetGraphicRequest : IRequest<OapGraphic>
    { 
        public GetGraphicRequest(int graphicId)
        {
            GraphicId = graphicId;
        }

        public int GraphicId {get; set;}
    }
}