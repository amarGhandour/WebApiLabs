using Microsoft.EntityFrameworkCore;

namespace WebApiLabs.Models
{
    public class ITIDBContext: DbContext
    {
        public ITIDBContext(DbContextOptions options): base(options) { }


       public  DbSet<Course> courses { get; set; }
        public DbSet<Topic> topics { get; set; }


    }
}
