using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Category;
using Application.ViewModel.Meal;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryInterface _category;

        public CategoryService(ICategoryInterface category)
        {
            _category = category;
        }
        public Tuple<List<CategoryViewModel>, int, int> GetCategories(int page, string search = "")
        {
            int pageSelected = page;
            int count = _category.CountCategory().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _category.GetCategories(search, pageSkip).Result;
            List<CategoryViewModel> category = new List<CategoryViewModel>();

            foreach (var item in list)
            {
                category.Add(new CategoryViewModel()
                {
                  CategoryId = item.CategoryId,
                  CategoryName = item.CategoryTitle
                });
            }
            return Tuple.Create(category, count, pageSelected);
        }

        public async Task<UpdateCategoryViewModel> GetCategoryById(string id)
        {
            var result = await _category.GetCategoryById(id);
            UpdateCategoryViewModel category=new UpdateCategoryViewModel();
            category.CategoryId = result.CategoryId;
            category.CategoryTitle = result.CategoryTitle;
            return category;
        }

        public bool InsertCategory(InsertCategoryViewModel model)
        {
           CategoryEntity category=new CategoryEntity();
           category.CategoryTitle = model.CategoryTitle;
           try
           {
                _category.InsertCategory(category);
                return true;
           }
           catch
           {
               return false;
           }
        }

        public bool UpdateCategory(UpdateCategoryViewModel model)
        {
            var category = _category.GetCategoryById(model.CategoryId).Result;
            category.CategoryTitle = model.CategoryTitle;
            try
            {
                _category.UpdateCategory(category);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(string id)
        {
            var category = _category.GetCategoryById(id).Result;
            try
            {
                _category.DeleteCategory(category);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
