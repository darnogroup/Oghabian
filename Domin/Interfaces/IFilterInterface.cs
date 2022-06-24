using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IFilterInterface
    {
        Task<IEnumerable<FoodEntity>> GetFoods(string search, int skip);
        Task<IEnumerable<FoodEntity>> GetFoodsWithMeal(string meal, int skip);
        Task<IEnumerable<FoodEntity>> GetFoodsWithMealAndSickness(string meal, string sickness, int skip);
        Task<IEnumerable<FoodEntity>> GetFoodsWithMealAndFilter(string meal, int calories, string carbohydrate, string fat, string protein, int skip);
        Task<IEnumerable<FoodEntity>> GetFoodsWithSicknessAndFilter(string sickness, int calories, string carbohydrate, string fat, string protein, int skip);
        Task<IEnumerable<FoodEntity>> GetFoodsFilter(string meal, string sickness, int calories, string carbohydrate, string fat, string protein, int skip);
        Task<IEnumerable<FoodEntity>> GetFoodsWithSickness(string sickness, int skip);
        Task<IEnumerable<FoodEntity>> GetFoodsWithFilter(int calories, string carbohydrate, string fat, string protein, int skip);
        int CountGetFoodsWithMeal(string meal);
        int CountGetFoodsWithMealAndSickness(string meal, string sickness);
        int CountGetFoodsWithMealAndFilter(string meal, int calories, string carbohydrate, string fat, string protein);
        int CountGetFoodsWithSicknessAndFilter(string sickness, int calories, string carbohydrate, string fat, string protein);
        int CountGetFoodsFilter(string meal, string sickness, int calories, string carbohydrate, string fat, string protein);
        int CountGetFoodsWithSickness(string sickness);
        int CountGetFoodsWithFilter(int calories, string carbohydrate, string fat, string protein);
        int CountFood();
    }
}
