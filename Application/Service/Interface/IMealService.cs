using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Meal;

namespace Application.Service.Interface
{
    public interface IMealService
    {
        Tuple<List<MealViewModel>, int, int> GetMeals(int page, string search = "");
        Task<UpdateMealViewModel> GetMealById(string id);
        bool InsertMeal(InsertMealViewModel model);
        bool UpdateMeal(UpdateMealViewModel model);
        bool DeleteMeal(string id);
    }
}
