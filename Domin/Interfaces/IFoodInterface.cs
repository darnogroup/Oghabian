using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IFoodInterface
    {
        Task<IEnumerable<FoodEntity>> GetFoods(string search, int skip);
        Task<FoodEntity> GetFoodById(string id);
        void InsertFood(FoodEntity food);
        void UpdateFood(FoodEntity food);
        void DeleteFood(FoodEntity food);
        int CountFood();
    }
}
