using Microsoft.EntityFrameworkCore;
using ShiftManagement.Web.Models;

namespace ShiftManagement.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Turn> Turns { get; set; }
    }
}