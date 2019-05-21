using Microsoft.EntityFrameworkCore;

namespace StudentApp.Models
{
    public class MojContext:DbContext
    {
        public MojContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=app.fit.ba;Database=studentforms;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=studentforms;Password=!8Byx76k");
        }

        public DbSet<Opstina> Opstinas { set; get; }
        public DbSet<Student> Students { set; get; }
    }
}
