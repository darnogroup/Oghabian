using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IGeneralInterface
    {
        Task<List<CategoryEntity>> GetCategories();
        Task<List<MealEntity>> GetMeals();
        Task<List<SicknessEntity>> GetSickness();
    }
}
