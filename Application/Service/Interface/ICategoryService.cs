using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Category;


namespace Application.Service.Interface
{
    public interface ICategoryService
    {
        Tuple<List<CategoryViewModel>, int, int> GetCategories(int page, string search = "");
        Task<UpdateCategoryViewModel> GetCategoryById(string id);
        bool InsertCategory(InsertCategoryViewModel model);
        bool UpdateCategory(UpdateCategoryViewModel model);
        bool DeleteCategory(string id);
    }
}
