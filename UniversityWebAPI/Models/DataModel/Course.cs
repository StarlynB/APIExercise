using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityWebAPI.Models.DataAccess;

namespace UniversityWebAPI.Models.DataModel
{

    public enum Level
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }

    [NotMapped]
    public class Course : BaseEntity
    {

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public Level Level { get; set; } = Level.Basic;

        
        public ICollection<Category>? Categories { get; set; }

        public virtual Category? Category { get; set; }

        
        public ICollection<Chapter>? chapter { get; set; } 

        public virtual Chapter? Chapters { get; set; }

        
        public ICollection<Student>? Students { get; set; }

        public virtual Student? Student { get; set;}
    }
}
