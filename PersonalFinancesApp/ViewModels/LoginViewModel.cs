using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using PersonalFinancesApp.Commands;
using PersonalFinancesApp.Views;
using PersonalFinancesApp.Models.BusinessLogicLayer;
using System.Diagnostics;

namespace PersonalFinancesApp.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        private string _username;
        private string _password;
        public User LoggedUser { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if(_password!=value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }
        public LoginViewModel()
        {
            LoggedUser = new User();
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
        }
        public void Register()
        {
            if (App.UserBLL.GetByUsername(Username) != null)
            {
                MessageBox.Show("Username already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            User newUser = new User
            {
                Username = Username,
                Password = Password,
                IsAdmin = false 
            };
            App.UserBLL.AddUser(newUser);
            MessageBox.Show("Registration successful! You can login now.");
        }
        public bool AccountExists(string username, string password)
        {
            LoggedUser = App.UserBLL.GetByUsername(username);
            if (LoggedUser != null && LoggedUser.Password == password)
            {
                return true;
            }
            return false;
        }
        public void Login()
        {

            if (AccountExists(Username, Password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Debug.Write(LoggedUser.IsAdmin);
                Debug.Write(LoggedUser.Username);
                Debug.Write(LoggedUser.Password);
                switch (LoggedUser.IsAdmin)
                {
                    case true:
                        {
                            new AdminWindow().Show();
                            AdminViewModel.Admin = LoggedUser;
                            Application.Current.MainWindow.Close();
                            break;
                        }
                    case false:
                        {
                            new UserWindow().Show();
                            UserViewModel.User = LoggedUser;
                            Application.Current.MainWindow.Close();
                            break;
                        }
                }

            }
            else
            {
                MessageBox.Show("Login failed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
