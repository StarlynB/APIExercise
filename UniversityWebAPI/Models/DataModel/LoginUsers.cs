using System.ComponentModel.DataAnnotations;

namespace UniversityWebAPI.Models.DataModel
{
    public class LoginUsers
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
