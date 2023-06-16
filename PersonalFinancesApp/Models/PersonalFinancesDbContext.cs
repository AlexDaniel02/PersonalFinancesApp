using Microsoft.EntityFrameworkCore;
using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinancesApp.Models
{
    public class PersonalFinancesDbContext:DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Port=5432;Database=PersonalFinances;User Id=postgres;Password=admin;";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
