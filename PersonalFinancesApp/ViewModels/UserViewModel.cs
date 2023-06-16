using PersonalFinancesApp.Commands;
using PersonalFinancesApp.Models.EntityLayer;
using PersonalFinancesApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalFinancesApp.ViewModels
{
    public class UserViewModel
    {
        public static User User { get; set; }
        public ICommand UsersCommand { get; set; }
        public ICommand ExpensesCommand { get; set; }
        public ICommand IncomesCommand { get; set; }
        public ICommand CategoriesCommand { get; set; }
        public ICommand StatisticsCommand { get; set; }
        public UserViewModel()
        {
            ExpensesCommand = new RelayCommand(ShowExpenses);
            IncomesCommand = new RelayCommand(ShowIncomes);
            StatisticsCommand = new RelayCommand(ShowStatistics);
        }
        public void ShowStatistics()
        {
            UserStatisticsViewModel.User = User;
            UserStatisticsViewModel viewModel = new UserStatisticsViewModel();
            UserStatisticsWindow statisticsWindow = new UserStatisticsWindow();
            statisticsWindow.DataContext = viewModel;
            statisticsWindow.Show();
        }
        public void ShowExpenses()
        {
            UserExpensesViewModel.User = User;
            new UserExpensesWindow().Show();
        }
        public void ShowIncomes()
        {
            UserIncomesViewModel.User = User;
            new UserIncomesWindow().Show();
        }
    }
}
