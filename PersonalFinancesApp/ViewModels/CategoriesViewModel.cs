using PersonalFinancesApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using PersonalFinancesApp.Models.EntityLayer;

namespace PersonalFinancesApp.ViewModels
{
    public class CategoriesViewModel : ViewModelBase
    {
        private ObservableCollection<Category> _categories;
        private Category _selectedCategory;
        private string _newCategoryName;

        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    OnPropertyChanged();
                }
            }
        }

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewCategoryName
        {
            get { return _newCategoryName; }
            set
            {
                if (_newCategoryName != value)
                {
                    _newCategoryName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCategoryCommand { get; set; }
        public ICommand UpdateCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }

        public CategoriesViewModel()
        {
            Categories = new(App.CategoryBLL.GetAllCategories());
            AddCategoryCommand = new RelayCommand(AddCategory);
            UpdateCategoryCommand = new RelayCommand(UpdateCategory);
            DeleteCategoryCommand = new RelayCommand(DeleteCategory);
        }

        private void AddCategory()
        {
            Category newCategory = new Category
            {
                Name = NewCategoryName
            };
            App.CategoryBLL.AddCategory(newCategory);
            Refresh();

        }

        private void UpdateCategory()
        {
            if (SelectedCategory == null)
            {
                MessageBox.Show("Please select a category to update");
            }
            if (string.IsNullOrWhiteSpace(NewCategoryName))
            {
                MessageBox.Show("Please enter a name for the category");
                return;
            }
            SelectedCategory.Name = NewCategoryName;
            App.CategoryBLL.UpdateCategory(SelectedCategory);
            Refresh();
        }
        private void DeleteCategory()
        {
            if (SelectedCategory != null)
            {
                App.CategoryBLL.DeleteCategory(SelectedCategory);
                Refresh();
                /*                SelectedCategory = null;
                */
            }
            else
            {
                MessageBox.Show("Please select a category to delete");
            }

        }
        private void Refresh()
        {
            Categories.Clear();

            foreach (Category category in App.CategoryBLL.GetAllCategories())
            {
                Categories.Add(category);
            }
        }
    }
}
