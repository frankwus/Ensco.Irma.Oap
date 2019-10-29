using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Graphic
{
    public class DeleteGraphicRequest : IRequest<bool>
    { 
        public DeleteGraphicRequest(int graphicId)
        {
            GraphicId = graphicId;
        }

        public int GraphicId {get; set;}
    }
}