using PersonalFinancesApp.Commands;
using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PersonalFinancesApp.ViewModels
{
    public class IncomesViewModel : ViewModelBase
    {
        private Income _selectedIncome;
        private string _name;
        private double _amount;
        private DateTime _date;
        private string _description;
        private string _username;
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
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
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
        public IncomesViewModel()
        {
            AddIncomeCommand = new RelayCommand(AddIncome);
            UpdateIncomeCommand = new RelayCommand(UpdateIncome);
            DeleteIncomeCommand = new RelayCommand(DeleteIncome);
            Incomes = new(App.IncomeBLL.GetAllIncomes());
            Date = DateTime.Now;
        }
        public void AddIncome()
        {
            User user = App.UserBLL.GetByUsername(Username);
            if (user == null)
            {
                MessageBox.Show("User doesn`t exist");
                return;
            }
            else
            {
                Income newIncome = new Income
                {
                    Name = Name,
                    Description = Description,
                    Amount = Amount,
                    User = user,
                    Date = Date.ToUniversalTime().AddDays(Date.Day - Date.ToUniversalTime().Day)

                };
                App.IncomeBLL.AddIncome(newIncome);
                Refresh();
            }
        }
        public void UpdateIncome()
        {
            User user = App.UserBLL.GetByUsername(Username);
            if (user == null)
            {
                MessageBox.Show("User doesn`t exist");
                return;
            }
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
                SelectedIncome.User = App.UserBLL.GetByUsername(Username);
                SelectedIncome.Date = Date.ToUniversalTime().AddDays(Date.Day - Date.ToUniversalTime().Day);
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
                Incomes.Add(income);
            }
        }
    }
}
