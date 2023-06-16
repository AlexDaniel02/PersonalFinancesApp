using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinancesApp.Models.EntityLayer
{
    public class User:BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
    