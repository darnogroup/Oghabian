using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IMealInterface
    {
        Task<IEnumerable<MealEntity>> GetMeals(string search, int skip);
        Task<MealEntity> GetMealById(string id);
        void InsertMeal(MealEntity meal);
        void UpdateMeal(MealEntity meal);
        void DeleteMeal(MealEntity meal);
        int CountMeal();
    }
}
