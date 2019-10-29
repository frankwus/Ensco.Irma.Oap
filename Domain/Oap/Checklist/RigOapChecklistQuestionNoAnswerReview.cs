using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class RigOapChecklistQuestionNoAnswerReview : EntityId<Guid>
    {        

        [ForeignKey("NoAnswer")]
        public Guid NoAnswerId { get; set; }
        public RigOapChecklistQuestionNoAnswerComment NoAnswer { get; set; }

        public int ReviewerId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string Comment { get; set; }
        public Nullable<NoAnswerReviewStatus> Status { get; set; }
    }

    public enum NoAnswerReviewStatus
    {        
        Pending,
        Rejected,
        Completed
    }
}
