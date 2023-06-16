using PersonalFinancesApp.Models.DataAccessLayer;
using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalFinancesApp.Models.BusinessLogicLayer
{
    public class IncomeBLL
    {
        private readonly IncomeDAL _incomeRepository;
        public IncomeBLL(IncomeDAL incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }
        public Income GetIncomeById(int id)
        {
            return _incomeRepository.GetByID(id);
        }
        public List<Income> GetAllIncomes()
        {
            return _incomeRepository.GetAll();
        }
        public void AddIncome(Income income)
        {
            if (ValidateIncome(income))
            {
                _incomeRepository.Insert(income);
            }   
        }
        public void UpdateIncome(Income income)
        {
            if (ValidateIncome(income))
            {
                _incomeRepository.Update(income);
            }
        }
        public void DeleteIncome(Income income)
        {
            var existingIncome = _incomeRepository.GetByID(income.Id);
            if (existingIncome == null)
            {
                MessageBox.Show("Income not found.");
                return;
            }
            _incomeRepository.Delete(income);
        }
        public bool ValidateIncome(Income income)
        {
            if (income.Amount == 0)
            {
                MessageBox.Show("Amount cannot be 0.");
                return false;
            }
            if (income.Name == null)
            {
                MessageBox.Show("Name cannot be empty.");
                return false;
            }
            if (income.Description == null)
            {
                MessageBox.Show("Description cannot be empty.");
                return false;
            }
            return true;
        }

    }
}
