using System;
using System.Collections.Generic;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistQuestionService: HistoricalEntityIdService<IrmaOapDbContext, IOapChecklistQuestionRepository, OapChecklistQuestion, int>, IOapChecklistQuestionService
    {
        public OapChecklistQuestionService(IOapChecklistQuestionRepository repository): base(repository)
        {

        }
         
        public IEnumerable<OapChecklistQuestion> GetAllSubGroupQuestions(int subGroupId)
        {
            return Repository.GetAllSubGroupQuestions(subGroupId);
        }
         
        public IEnumerable<OapChecklistQuestion> GetAllChecklistQuestions(int checklistId)
        {
            return Repository.GetAllChecklistQuestions(checklistId);
        }

        public IEnumerable<OapChecklistQuestion> GetAllTopicQuestions(int topicId)
        {
            return Repository.GetAllTopicQuestions(topicId);
        }

        public IEnumerable<OapChecklistQuestion> GetAllProtocolQuestions(DateTime startDate, DateTime endDate)
        {
            return Repository.GetAllProtocolQuestions(startDate, endDate);
        }
    }
}
