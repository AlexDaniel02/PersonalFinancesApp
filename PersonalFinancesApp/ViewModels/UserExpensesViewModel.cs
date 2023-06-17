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
    public class UserExpensesViewModel : ViewModelBase
    {
        public static User User { get; set; }
        private Expense _selectedExpense;
        private string _name;
        private double _amount;
        private DateTime _date;
        private Category _category;
        private string _description;
        public ObservableCollection<Expense> Expenses { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
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
        public UserExpensesViewModel()
        {
            AddExpenseCommand = new RelayCommand(AddExpense);
            UpdateExpenseCommand = new RelayCommand(UpdateExpense);
            DeleteExpenseCommand = new RelayCommand(DeleteExpense);
            Expenses = new(App.ExpenseBLL.GetAllExpenses().Where(expense => expense.User == User));
            Categories = new(App.CategoryBLL.GetAllCategories());
            Date = DateTime.Now;
        }
        public void AddExpense()
        {
            Expense newExpense = new Expense
            {
                Name = Name,
                Description = Description,
                Amount = Amount,
                User = User,
                Category = Category,
                Date = Date.ToUniversalTime().AddDays(Date.Day - Date.ToUniversalTime().Day)
            };
            App.ExpenseBLL.AddExpense(newExpense);
            Refresh();
        }
        public void UpdateExpense()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || Amount == 0 || Category == null)
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }
            if (SelectedExpense != null)
            {
                SelectedExpense.Name = Name;
                SelectedExpense.Description = Description;
                SelectedExpense.Amount = Amount;
                SelectedExpense.Date = Date.ToUniversalTime().AddDays(Date.Day-Date.ToUniversalTime().Day);
                SelectedExpense.Category = Category;
                App.ExpenseBLL.UpdateExpense(SelectedExpense);
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
                if (expense.User == User)
                {
                    Expenses.Add(expense);
                }
            }
        }
    }
}

