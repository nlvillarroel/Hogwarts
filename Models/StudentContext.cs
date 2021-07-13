using Microsoft.EntityFrameworkCore;

namespace Students.Models
{
    public class StudentContext: DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options): base(options)
        { 
        
        }
        public DbSet<Student> Students { get; set; }
    }
}
