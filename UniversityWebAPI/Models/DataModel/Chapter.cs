using System.ComponentModel.DataAnnotations;
using UniversityWebAPI.Models.DataAccess;

namespace UniversityWebAPI.Models.DataModel
{
    public class Chapter : BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();

        [Required]
        public string List  = string.Empty;

        
    }
}
