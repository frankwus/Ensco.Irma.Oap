using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensco.Irma.Models.Domain.Oap.Checklist
{
    public class OapChecklistQuestionDataType : Entity<int>
    {
        [Column(Order = 5)]
        [StringLength(10)]
        public string Code { get; set; }

        [Column(Order = 10)]
        [StringLength(1024)]
        public string Description { get; set; }
    }
}
