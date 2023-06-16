using PersonalFinancesApp.Models;
using PersonalFinancesApp.Models.BusinessLogicLayer;
using PersonalFinancesApp.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalFinancesApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static UserDAL _userDAL { get; set; }
        private static ExpenseDAL _expenseDAL { get; set; }
        private static IncomeDAL _incomeDAL { get; set; }
        private static CategoryDAL _categoryDAL { get; set; }
        public static UserBLL UserBLL { get; private set; }
        public static ExpenseBLL ExpenseBLL { get; private set; }
        public static IncomeBLL IncomeBLL { get; private set; }
        public static CategoryBLL CategoryBLL { get; private set; }
        public App()
        {
            PersonalFinancesDbContext dbContext = new PersonalFinancesDbContext();
            _userDAL = new UserDAL(dbContext);
            UserBLL = new UserBLL(_userDAL);
            UserBLL.GetAllUsers();
            _expenseDAL = new ExpenseDAL(dbContext);
            ExpenseBLL = new ExpenseBLL(_expenseDAL);
            ExpenseBLL.GetAllExpenses();
            _incomeDAL = new IncomeDAL(dbContext);
            IncomeBLL = new IncomeBLL(_incomeDAL);
            IncomeBLL.GetAllIncomes();
            _categoryDAL = new CategoryDAL(dbContext);
            CategoryBLL = new CategoryBLL(_categoryDAL);
            CategoryBLL.GetAllCategories();
        }
    }
}
