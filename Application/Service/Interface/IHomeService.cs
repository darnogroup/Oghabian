using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Home;
using Application.ViewModel.Home.Blogs;
using Application.ViewModel.Home.Card;
using Application.ViewModel.Home.Foods;
using Application.ViewModel.Home.Profile;

namespace Application.Service.Interface
{
    public interface IHomeService
    {
        Tuple<List<BlogViewModel>, int, int> GetBlogs(string category, int page, string search);
        Task<BlogDetailViewModel> GetBlogDetail(string id);
        void InsertArticleComment(InsertCommentViewModel model);
        void InsertFoodComment(InsertFoodCommentViewModel model);
        Tuple<List<FoodCartViewModel>, int, int> GetFoods(string search,string meal, string sickness, string calories, string carbohydrate, string fat, string protein, int page);
        Tuple<FoodDetailViewModel, List<FoodImageViewModel>, List<FoodPropertyViewModel>> GetFoodDetail(string id);
        Task<List<FoodCartViewModel>> GetLastFoods();
        Task<List<BlogViewModel>> GetFourArticle();
        void AddToCart(AddToCardViewModel model);
        Tuple<List<CartItemViewModel>,CartDetailViewModel> GetCart(string user);
        void RemoveOrderDetail(string id);
        Task<List<UserQuestionViewModel>> Questions();
        Task<List<UserAnswerViewModel>> Answer(string id);
        void InsertAnswer(InsertUserAnswerViewModel model);
        void InsertQuestion(InsertUserQuestionViewModel model);
        void Insert(ContactViewModel model);
    }
}
