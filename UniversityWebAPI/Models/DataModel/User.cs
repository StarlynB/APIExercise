using System.ComponentModel.DataAnnotations;
using UniversityWebAPI.Models.DataAccess;

namespace UniversityWebAPI.Models.DataModel
{
    public class User : BaseEntity
    {

        [Required, MaxLength(55)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
