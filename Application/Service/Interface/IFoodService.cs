﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Article;
using Application.ViewModel.Food;
using Application.ViewModel.Selection;

namespace Application.Service.Interface
{
    public interface IFoodService
    {
        Tuple<List<FoodViewModel>, int, int> GetFoods(int page, string search = "");
        Task<UpdateFoodViewModel> GetFoodById(string id);
        bool InsertFood(InsertFoodViewModel model);
        bool UpdateFood(UpdateFoodViewModel model);
        bool DeleteFood(string id);
        Task<List<SelectViewModel>> GetMeals();
        Task<List<SelectViewModel>> GetSickness();
        Task<FoodSeoViewModel> GetSeoViewModel(string id);
        void ChangeSeo(FoodSeoViewModel model);

        Tuple<List<CommentFoodViewModel>, int, int> GetComment(string id, int page = 1, string search = "");
        Task<CommentFoodDetailViewModel> GetCommentFoodDetail(string id);
        void UpdateComment(CommentFoodDetailViewModel model);
        void DeleteComment(string id);
    }
}
