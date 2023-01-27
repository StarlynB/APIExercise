using Microsoft.EntityFrameworkCore;
using UniversityWebAPI.Models.DataAccess;
using UniversityWebAPI.Models.DataModel;

namespace UniversityWebAPI.DataAccess
{
    public class UniversitysDBContext: DbContext
    {

        public UniversitysDBContext(DbContextOptions<UniversitysDBContext> options) : base(options)
        {
        
        }
        
        public DbSet<LoginUsers> LoginUsers { get; set; }
        public DbSet<BaseEntity> baseEntities { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Chapter> chapters { get; set; }    
        public DbSet<Course> courses { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<User> users { get; set; }
    }
}
