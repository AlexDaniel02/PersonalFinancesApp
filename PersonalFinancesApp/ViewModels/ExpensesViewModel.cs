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
    public class ExpensesViewModel : ViewModelBase
    {
        private Expense _selectedExpense;
        private string _name;
        private double _amount;
        private DateTime _date;
        private string _description;
        private string _username;
        private Category _category;
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Expense> Expenses { get; set; }
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
        public Category Category
        {
            get { return _category; }
            set
            {
                _category = value;
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
        public Expense SelectedExpense
        {
            get { return _selectedExpense; }
            set
            {
                _selectedExpense = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddExpenseCommand { get; set; }
        public ICommand UpdateExpenseCommand { get; set; }
        public ICommand DeleteExpenseCommand { get; set; }
        public ExpensesViewModel()
        {
            AddExpenseCommand = new RelayCommand(AddExpense);
            UpdateExpenseCommand = new RelayCommand(UpdateExpense);
            DeleteExpenseCommand = new RelayCommand(DeleteExpense);
            Expenses = new(App.ExpenseBLL.GetAllExpenses());
            Categories = new(App.CategoryBLL.GetAllCategories());
        }
        public void AddExpense()
        {
            User user = App.UserBLL.GetByUsername(Username);
            if (user == null)
            {
                MessageBox.Show("User doesn`t exist");
                return;
            }
            Expense newExpense = new Expense
            {
                Name = Name,
                Description = Description,
                Amount = Amount,
                User = user,
                Category = Category,
                Date = Date.ToUniversalTime()
            };
            App.ExpenseBLL.AddExpense(newExpense);
            Refresh();
        }
        public void UpdateExpense()
        {
            User user = App.UserBLL.GetByUsername(Username);
            if (user == null)
            {
                MessageBox.Show("User doesn`t exist");
                return;
            }
            if(string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || Category==null || Amount==0)
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }
            {
                SelectedExpense.Name = Name;
                SelectedExpense.Description = Description;
                SelectedExpense.Amount = Amount;
                SelectedExpense.User = App.UserBLL.GetByUsername(Username);
                SelectedExpense.Date = Date;
                SelectedExpense.Category = Category;
                App.ExpenseBLL.UpdateExpense(SelectedExpense);
                SelectedExpense = null;
                Refresh();
            }
        }
        public void DeleteExpense()
        {
            if (SelectedExpense != null)
            {
                App.ExpenseBLL.DeleteExpense(SelectedExpense);
                Expenses.Remove(SelectedExpense);
            }
        }
        public void Refresh()
        {
            Expenses.Clear();
            foreach (var expense in App.ExpenseBLL.GetAllExpenses())
            {
                Expenses.Add(expense);
            }
        }
    }
}

