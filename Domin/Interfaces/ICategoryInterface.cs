using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ICategoryInterface
    {
        Task<IEnumerable<CategoryEntity>> GetCategories(string search, int skip);
        Task<CategoryEntity> GetCategoryById(string id);
        void InsertCategory(CategoryEntity category);
        void UpdateCategory(CategoryEntity category);
        void DeleteCategory(CategoryEntity category);
        int CountCategory();
    }
}
