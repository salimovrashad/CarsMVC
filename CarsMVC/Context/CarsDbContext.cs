using CarsMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarsMVC.Context
{
    public class CarsDbContext : IdentityDbContext
    {
        public CarsDbContext(DbContextOptions opt) : base(opt)
        {
        }
        public DbSet<Accesories> Accesories { get; set; }
    }
}
