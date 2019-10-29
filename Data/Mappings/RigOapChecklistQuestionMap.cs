using Ensco.Irma.Models.Domain.Oap.Checklist;
using System.Data.Entity.ModelConfiguration;

namespace Ensco.Irma.Data.Mappings
{
    public class RigOapChecklistQuestionMap : EntityTypeConfiguration<RigOapChecklistQuestion>
    {
        public RigOapChecklistQuestionMap()
        {
            //Configures one to one relationship  between Question and NoAnswerComment
            //this.HasRequired(s => s.NoAnswerComment).WithRequiredPrincipal();  
        }
    }
     
}
