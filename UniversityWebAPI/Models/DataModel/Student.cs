using System.ComponentModel.DataAnnotations;
using UniversityWebAPI.Models.DataAccess;

namespace UniversityWebAPI.Models.DataModel
{
    public class Student : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime Dob { get; set; }

        public ICollection<Course>? Courses { get; set; }

    }
}
