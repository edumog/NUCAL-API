
using System.ComponentModel.DataAnnotations;

namespace NUCAL.Application.Core.DTOs
{
    public partial class UserCreationDTO
    {
        [Required]
        [MaxLength(256)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool KeepLoggedIn { get; set; } = false;
    }
}
