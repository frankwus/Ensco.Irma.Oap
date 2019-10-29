using System;
using System.Collections.Generic;
using System.Linq;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;

namespace Ensco.Irma.Services.Oap
{
    public class OapChecklistQuestionTagMapService : EntityIdService<IrmaOapDbContext, IOapChecklistQuestionTagMapRepository, OapChecklistQuestionTagMap, int>, IOapChecklistQuestionTagMapService
    {
        public OapChecklistQuestionTagMapService(IOapChecklistQuestionTagMapRepository repository) : base(repository)
        {

        }

        public IEnumerable<OapChecklistQuestionTagMap> GetAllTagsByQuestion(int oapChecklistQuestionId)
        {
            return Repository.GetAllTagsByQuestion(oapChecklistQuestionId);
        }

        public OapChecklistQuestionTagMap GetByQuestionTag(int oapChecklistQuestionId, int oapTagId)
        {
            return Repository.GetByQuestionTag(oapChecklistQuestionId, oapTagId).FirstOrDefault();
        }

        public IEnumerable<OapChecklistQuestion> GetQuestions(int oapTagId)
        {
            return Repository.GetQuestions(oapTagId);
        }

        public IEnumerable<OapChecklistQuestionTag> GetTags(int oapChecklistQuestionId)
        {
            return Repository.GetTags(oapChecklistQuestionId);
        }


    }
}
