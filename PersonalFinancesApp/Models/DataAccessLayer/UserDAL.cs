using Microsoft.EntityFrameworkCore;
using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinancesApp.Models.DataAccessLayer
{
    public class UserDAL : BaseDAL<User>
    {
        public UserDAL(PersonalFinancesDbContext dbContext) : base(dbContext)
        {

        }
        public User GetByUsername(string username)
        {
            return _dbSet.FirstOrDefault(u => u.Username == username);
        }
    }
}
