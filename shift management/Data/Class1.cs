using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shift_management.Models;

namespace shift_management.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Turn> Turns { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ShiftDB;Trusted_Connection=True;");
            }
        }
    }
}
