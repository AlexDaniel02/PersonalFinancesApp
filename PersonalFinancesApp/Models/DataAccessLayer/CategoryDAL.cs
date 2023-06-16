using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinancesApp.Models.DataAccessLayer
{
    public class CategoryDAL :BaseDAL<Category>
    {
        public CategoryDAL(PersonalFinancesDbContext dbContext) : base(dbContext)
        {
        }   
        
    }
}
