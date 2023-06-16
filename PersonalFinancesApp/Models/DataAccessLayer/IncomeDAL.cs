using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinancesApp.Models.DataAccessLayer
{
    public class IncomeDAL : BaseDAL<Income>
    {
        public IncomeDAL(PersonalFinancesDbContext dbContext) : base(dbContext)
        {
        }
    }
}
