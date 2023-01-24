using System.ComponentModel.DataAnnotations;

namespace UniversityWebAPI.Models.DataModel
{
    public class LoginUsers
    {
        public int? Id { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
