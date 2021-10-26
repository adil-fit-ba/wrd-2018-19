using FIT_Api_Examples.Modul1.Models;
using FIT_Api_Examples.Modul2.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FIT_Api_Examples.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectTask> ProjectTask { get; set; }
        public DbSet<TimeTracking> TimeTracking { get; set; }
        public DbSet<Project> Project { get; set; }

        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Ispit20210601Posalji> Ispit20210601Posalji { get; set; }
        public DbSet<Ispit20210702Posalji> Ispit20210702Posalji { get; set; }
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }
    }
}
