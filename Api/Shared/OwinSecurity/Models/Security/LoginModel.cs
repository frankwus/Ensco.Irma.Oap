using System.ComponentModel.DataAnnotations;

namespace Ensco.Irma.Oap.Api.Common.Models.Security
{
    public class LoginModel
    {

        [Required]
        [StringLength(128)]
        public string LoginId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(128)]
        public string Password { get; set; }

        [Required]
        [StringLength(32)]
        public string Culture { get; set; }

        [Required]
        public bool RememberMe { get; set; } = false;

    }
}