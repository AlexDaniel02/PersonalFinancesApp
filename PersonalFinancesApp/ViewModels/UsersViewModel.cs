using PersonalFinancesApp.Commands;
using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace PersonalFinancesApp.ViewModels
{

    public class UsersViewModel : ViewModelBase
    {
        private string _newUsername;
        private string _newPassword;
        private bool _isAdmin;
        public ObservableCollection<User> Users { get; set; }
        private User _selectedUser;
        public string NewUsername
        {
            get { return _newUsername; }
            set
            {
                _newUsername = value;
                OnPropertyChanged();
            }
        }
        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public UsersViewModel()
        {
            Users = new(App.UserBLL.GetAllUsers());
            AddUserCommand = new RelayCommand(AddUser);
            UpdateUserCommand = new RelayCommand(UpdateUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);
        }

        private void AddUser()
        {
            if (App.UserBLL.GetByUsername(NewUsername) != null)
            {
                MessageBox.Show("Username already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            User newUser = new User
            {
                Username = NewUsername,
                Password = NewPassword,
                IsAdmin = IsAdmin
            };
            App.UserBLL.AddUser(newUser);
            Users.Add(newUser);
        }
        private void UpdateUser()
        {
            if (string.IsNullOrWhiteSpace(NewUsername)|| string.IsNullOrWhiteSpace(NewPassword))
            {
                MessageBox.Show("Username and password cannot be empty!");
                return;
            }
            if (SelectedUser == null)
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }
            SelectedUser.Username = NewUsername;
            SelectedUser.Password = NewPassword;
            SelectedUser.IsAdmin = IsAdmin;
            App.UserBLL.UpdateUser(SelectedUser);
            Refresh();
        }

        private void DeleteUser()
        {
            if (SelectedUser != null)
            {
                App.UserBLL.DeleteUser(SelectedUser);
                Refresh();
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }
        private void Refresh()
        {
            Users.Clear();
            foreach (var user in App.UserBLL.GetAllUsers())
            {
                Users.Add(user);
            }
        }
    }
}

