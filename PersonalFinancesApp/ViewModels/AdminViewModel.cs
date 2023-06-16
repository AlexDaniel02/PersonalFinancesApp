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
    public class AdminViewModel
    {
        public static User Admin { get; set; }
        public ICommand UsersCommand { get; set; }
        public ICommand ExpensesCommand { get; set; }
        public ICommand IncomesCommand { get; set; }
        public ICommand CategoriesCommand { get; set; }
        public AdminViewModel()
        {
            UsersCommand = new RelayCommand(ShowUsers);
            ExpensesCommand = new RelayCommand(ShowExpenses);
            IncomesCommand = new RelayCommand(ShowIncomes);
            CategoriesCommand = new RelayCommand(ShowCategories);
        }
        public AdminViewModel(User admin)
        {
            Admin = admin;
        }
        public void ShowUsers()
        {
            new UsersWindow().Show();
        }
        public void ShowCategories()
        {
            new CategoriesWindow().Show();
        }
        public void ShowIncomes()
        {
            new IncomesWindow().Show();
        }
        public void ShowExpenses()
        {
            new ExpensesWindow().Show();
        }
    }
}
