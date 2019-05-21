using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT_Online_shop.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace FIT_Online_shop.EF
{
    public class MojDbContext : DbContext
    {
        public DbSet<Kupac> Kupac { set; get; }
        public DbSet<Proizvod> Proizvod { set; get; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { set; get; }
        public MojDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=app.fit.ba,1431;Database=fitonlineshop;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=fitonlineshop;Password=Tw9p7!i2");
        }
    }
}
