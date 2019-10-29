using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist
{
    public class GetChecklistByTitleRequest : IRequest<OapChecklist>
    { 
        public GetChecklistByTitleRequest(string title)
        {
            Title = title;
        }

        public string Title {get; set;}
    }
}