using System.ComponentModel.DataAnnotations;
using UniversityWebAPI.Models.DataAccess;

namespace UniversityWebAPI.Models.DataModel
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        [Required] //Crea una relacion con cursos
        public ICollection<Course>? courses { get; set; }

        public Course? Course { get; set; }

    }
}
