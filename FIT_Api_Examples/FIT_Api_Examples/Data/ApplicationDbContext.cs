using FIT_Api_Examples.Models;
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
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }
    }
}
