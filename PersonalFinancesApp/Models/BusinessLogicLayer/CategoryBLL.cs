using PersonalFinancesApp.Models.DataAccessLayer;
using PersonalFinancesApp.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalFinancesApp.Models.BusinessLogicLayer
{
    public class CategoryBLL
    {
        private readonly CategoryDAL _categoryRepository;

        public CategoryBLL(CategoryDAL categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetByID(id);
        }
        
        public void AddCategory(Category category)
        {
            if (ValidateCategory(category))
            {
                _categoryRepository.Insert(category);
            }
        }

        public void UpdateCategory(Category category)
        {
            if (ValidateCategory(category))
            {
                var existingCategory = _categoryRepository.GetByID(category.Id);
                if (existingCategory == null)
                {
                    MessageBox.Show("Category doesn`t exist!");
                    return;
                }
                _categoryRepository.Update(existingCategory);
            }
        }
        
        public void DeleteCategory(Category category)
        {
            var existingCategory = _categoryRepository.GetByID(category.Id);
            if (existingCategory == null)
            {
                MessageBox.Show("Category doesn`t exist!");
                return;
            }
            _categoryRepository.Delete(existingCategory);
        }
        
        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        private bool ValidateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                MessageBox.Show("Category name is required!");
                return false;
            }
            return true;
        }
    }
}
