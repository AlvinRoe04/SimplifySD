using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimplifySD.Models;

namespace SimplifySD.DBContext;
public class SimplifyContext : IdentityDbContext
{
    public SimplifyContext(DbContextOptions<SimplifyContext> options) : base(options){}

    public DbSet<Individual> Individuals { get; set; }
    public DbSet<Staff> Staffs { get; set; }
}