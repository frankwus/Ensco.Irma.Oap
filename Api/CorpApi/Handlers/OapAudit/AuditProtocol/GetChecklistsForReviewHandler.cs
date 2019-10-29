using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.OapAudits.AuditProtocol
{
    public class GetChecklistsForReviewHandler : IRequestHandler<GetChecklistsForReviewRequest, IEnumerable<RigOapChecklist>>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }

        public GetChecklistsForReviewHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        Task<IEnumerable<RigOapChecklist>> IRequestHandler<GetChecklistsForReviewRequest, IEnumerable<RigOapChecklist>>.Handle(GetChecklistsForReviewRequest request, CancellationToken cancellationToken)
        {
            var cl = RigOapChecklistService.GetChecklistsForReview(request.SearchBy, request.ChecklistId, request.FromDate, request.ToDate);
            return Task.FromResult(cl);
        }
    }
}