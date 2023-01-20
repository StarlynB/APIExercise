using UniversityWebAPI.Models.DataModel;

namespace UniversityWebAPI.Services
{
    public interface IStudentsServices
    {
        IEnumerable<Student> GetStudentsWithCourse();
        IEnumerable<Student> GetStudentsWithNotCourse();
    }
}
