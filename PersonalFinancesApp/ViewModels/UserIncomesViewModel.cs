using PersonalFinancesApp.Commands;
using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace PersonalFinancesApp.ViewModels
{
    public class UserIncomesViewModel : ViewModelBase
    {
        public static User User { get; set; }
        private Income _selectedIncome;
        private string _name;
        private double _amount;
        private DateTime _date;
        private string _description;
        public ObservableCollection<Income> Incomes { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        public Income SelectedIncome
        {
            get { return _selectedIncome; }
            set
            {
                _selectedIncome = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddIncomeCommand { get; set; }
        public ICommand UpdateIncomeCommand { get; set; }
        public ICommand DeleteIncomeCommand { get; set; }
        public UserIncomesViewModel()
        {
            AddIncomeCommand = new RelayCommand(AddIncome);
            UpdateIncomeCommand = new RelayCommand(UpdateIncome);
            DeleteIncomeCommand = new RelayCommand(DeleteIncome);
            Incomes = new(App.IncomeBLL.GetAllIncomes().Where(income => income.User == User));
        }
        public void AddIncome()
        {
            Income newIncome = new Income
            {
                Name = Name,
                Description = Description,
                Amount = Amount,
                User = User,
                Date = Date.ToUniversalTime()
            };
            App.IncomeBLL.AddIncome(newIncome);
            Refresh();
        }
        public void UpdateIncome()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || Amount == 0)
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }
            if (SelectedIncome != null)
            {
                SelectedIncome.Name = Name;
                SelectedIncome.Description = Description;
                SelectedIncome.Amount = Amount;
                SelectedIncome.Date = Date;
                App.IncomeBLL.UpdateIncome(SelectedIncome);
                Refresh();
            }
        }
        public void DeleteIncome()
        {
            if (SelectedIncome != null)
            {
                App.IncomeBLL.DeleteIncome(SelectedIncome);
                Incomes.Remove(SelectedIncome);
            }
        }
        public void Refresh()
        {
            Incomes.Clear();
            foreach (var income in App.IncomeBLL.GetAllIncomes())
            {
                if (income.User == User)
                {
                    Incomes.Add(income);
                }
            }
        }
    }
}
