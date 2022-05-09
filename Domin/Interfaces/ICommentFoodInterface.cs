using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ICommentFoodInterface
    {
        Task<IEnumerable<CommentFoodEntity>> GetCommentFoods(string parentId,string search, int skip);
        Task<CommentFoodEntity> GetCommentFoodById(string id);
        void InsertCommentFood(CommentFoodEntity commentFood);
        void UpdateCommentFood(CommentFoodEntity commentFood);
        void DeleteCommentFood(CommentFoodEntity commentFood);
        int CountCommentFood();
    }
}
