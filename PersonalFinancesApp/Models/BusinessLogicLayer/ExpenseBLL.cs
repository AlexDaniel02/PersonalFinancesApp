using PersonalFinancesApp.Models.DataAccessLayer;
using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalFinancesApp.Models.BusinessLogicLayer
{
    public class ExpenseBLL
    {
        private readonly ExpenseDAL _expenseRepository;
        public ExpenseBLL(ExpenseDAL expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public Expense GetExpenseById(int id)
        {
            return _expenseRepository.GetByID(id);
        }
        public List<Expense> GetAllExpenses()
        {
            return _expenseRepository.GetAll();
        }
        public void AddExpense(Expense expense)
        {
            if (ValidateExpense(expense))
            {
                _expenseRepository.Insert(expense);
            }
        }
        public void UpdateExpense(Expense expense)
        {
            if (ValidateExpense(expense))
            {
                _expenseRepository.Update(expense);
            }
        }
        public void DeleteExpense(Expense expense)
        {
            var existingExpense = _expenseRepository.GetByID(expense.Id);
            if (existingExpense == null)
            {
                MessageBox.Show("Income not found.");
                return;
            }
            _expenseRepository.Delete(expense);
        }
        public bool ValidateExpense(Expense expense)
        {
            if (expense.Amount == 0)
            {
                MessageBox.Show("Amount cannot be 0.");
                return false;
            }
            if (expense.Date == null)
            {
                MessageBox.Show("Date cannot be empty.");
                return false;
            }
            if (expense.Name.Length==0)
            {
                MessageBox.Show("Name cannot be empty.");
                return false;
            }
            if(expense.Category==null)
            {
                MessageBox.Show("Category cannot be empty.");
                return false;
            }
            if(expense.Description.Length==0)
            {
                MessageBox.Show("Description cannot be empty.");
                return false;
            }
            return true;
        }
    }
}
