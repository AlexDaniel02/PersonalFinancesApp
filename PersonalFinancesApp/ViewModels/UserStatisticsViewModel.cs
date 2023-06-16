using PersonalFinancesApp.Commands;
using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace PersonalFinancesApp.ViewModels
{
    public class UserStatisticsViewModel : ViewModelBase
    {
        public static User User { get; set; }
        private DateTime _startDate;
        private DateTime _endDate;
        private string _selectedMonth;
        private ObservableCollection<Category> _categories;
        private Category _selectedCategory;
        private double _moneyReceived;
        private double _moneySpent;
        private double _moneySaved;
        private double _monthReceived;
        private double _monthSpent;
        private double _categorySpent;
        private double _monthSaved;
        public List<string> Months { get; set; }
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        public string SelectedMonth
        {
            get { return _selectedMonth; }
            set
            {
                _selectedMonth = value;
                OnPropertyChanged();
                CalculateMonthSpent();
                CalculateMonthReceived();
                CalculateMonthSaved();
            }
        }

        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                CalculateCategorySpent();
                OnPropertyChanged();
            }
        }

        public double MoneyReceived
        {
            get { return _moneyReceived; }
            set
            {
                _moneyReceived = value;
                OnPropertyChanged();
            }
        }

        public double MoneySpent
        {
            get { return _moneySpent; }
            set
            {
                _moneySpent = value;
                OnPropertyChanged();
            }
        }

        public double MoneySaved
        {
            get { return _moneySaved; }
            set
            {
                _moneySaved = value;
                OnPropertyChanged();
            }
        }

        public double MonthSpent
        {
            get { return _monthSpent; }
            set
            {
                _monthSpent = value;
                OnPropertyChanged();
            }
        }
        public double MonthReceived
        {
            get { return _monthReceived; }
            set
            {
                _monthReceived = value;
                OnPropertyChanged();
            }
        }
        public double MonthSaved
        {
            get { return _monthSaved; }
            set
            {
                _monthSaved = value;
                OnPropertyChanged();
            }
        }
        public double CategorySpent
        {
            get { return _categorySpent; }
            set
            {
                _categorySpent = value;
                OnPropertyChanged();
            }
        }   

        public ICommand CalculateByPeriodCommand { get; set; }
        public UserStatisticsViewModel()
        {
            CalculateByPeriodCommand = new RelayCommand(CalculatePeriodSavings);
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            Categories = new(App.CategoryBLL.GetAllCategories());
            Months = new List<string> { "January", "February", "March", "April", "May", "June", "July"  , "August", "September", "October", "November", "December" };
        }
        public void CalculatePeriodSavings()
        {

            CalculateMoneySpent();
            CalculateMoneyReceived();
            CalculateMoneySaved();
        }
        private void CalculateMoneySaved()
        {
            MoneySaved = MoneyReceived - MoneySpent;
        }

        private void CalculateMoneySpent()
        {
            MoneySpent = App.ExpenseBLL.GetAllExpenses().Where(expense => expense.User == User &&
                         expense.Date >= StartDate && expense.Date <= EndDate).Sum(expense => expense.Amount);
        }
        private void CalculateMoneyReceived()
        {
            MoneyReceived = App.IncomeBLL.GetAllIncomes().Where(income => income.User == User &&
            income.Date >= StartDate && income.Date <= EndDate).Sum(income => income.Amount);

        }
        public void CalculateMonthSpent()
        {
            MonthSpent = App.ExpenseBLL.GetAllExpenses().Where(expense => expense.User == User &&
                expense.Date.Month == Months.IndexOf(SelectedMonth) + 1).Sum(expense => expense.Amount);

        }
        public void CalculateMonthReceived()
        {
            MonthReceived = App.IncomeBLL.GetAllIncomes().Where(income => income.User == User &&
               income.Date.Month == Months.IndexOf(SelectedMonth) + 1).Sum(income => income.Amount);

        }

        public void CalculateMonthSaved()
        {
            MonthSaved = MonthReceived - MonthSpent;

        }
        public void CalculateCategorySpent()
        {
            CategorySpent = App.ExpenseBLL.GetAllExpenses().Where(expense => expense.User == User &&
                expense.Category == SelectedCategory).Sum(expense => expense.Amount);
        }



    }
}
