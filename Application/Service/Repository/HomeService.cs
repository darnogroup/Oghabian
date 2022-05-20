using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Article;
using Application.ViewModel.Home;
using Application.ViewModel.Home.Blogs;
using Application.ViewModel.Home.Card;
using Application.ViewModel.Home.Foods;
using Application.ViewModel.Home.Profile;
using Domin.Entities;
using Domin.Enum;
using Domin.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Service.Repository
{
    public class HomeService:IHomeService
    {
        private readonly IHomeInterface _home;
        private readonly ICommentArticleInterface _commentArticle;
        private readonly IOrderInterface _order;
        private readonly ICommentFoodInterface _commentFood;
        private readonly IFoodInterface _food;
        private readonly IUserInterface _user;
        private readonly IProfileInterface _profile;

        private readonly IContactInterface _contact;

        public HomeService(IHomeInterface home, ICommentArticleInterface commentArticle, IOrderInterface order, ICommentFoodInterface commentFood, IFoodInterface food, IUserInterface user, IProfileInterface profile, IContactInterface contact)
        {
            _home = home;
            _commentArticle = commentArticle;
            _order = order;
            _commentFood = commentFood;
            _food = food;
            _user = user;
            _profile = profile;
            _contact = contact;
        }
        public Tuple<List<BlogViewModel>, int, int> GetBlogs(string category, int page, string search)
        {
            int count;
            IEnumerable<ArticleEntity> list;
            int pageSelected = page;
            if (!string.IsNullOrEmpty(category))
            {
                 count = _home.CountFilterArticles(category).PageCount(10);
                int pageSkip = (page - 1) * 10;
                 list = _home.GetFilterArticles(category, search, pageSkip).Result;
            }
            else
            {


                 count = _home.CountArticles().PageCount(10);
                int pageSkip = (page - 1) * 10;
                 list = _home.GetArticles( search, pageSkip).Result;
            }

            List<BlogViewModel> blog = new List<BlogViewModel>();

            foreach (var item in list)
            {
                blog.Add(new BlogViewModel()
                {
                  ImagePath = item.ArticleImage,
                  BlogId = item.ArticleId,
                  Category = item.Category.CategoryTitle,
                  Summary = item.Summary,
                  CreateTime = item.CreatedTime.SolarYear(),
                  Time = item.TimeStudy,
                  Title = item.ArticleTitle
                });
            }
            return Tuple.Create(blog, count, pageSelected);
        }

        public async Task<BlogDetailViewModel> GetBlogDetail(string id)
        {
            var result = await _home.GetArticleById(id);
            BlogDetailViewModel blog=new BlogDetailViewModel();
            blog.ImagePath = result.ArticleImage;
            blog.Category = result.Category.CategoryTitle;
            blog.Summary = result.Summary;
            blog.CreateTime = result.CreatedTime.SolarYear();
            blog.Title = result.ArticleTitle;
            blog.Visit = result.VisitCount;
            blog.Time = result.TimeStudy;
            blog.BlogId = result.ArticleId;
            blog.Tags = result.ArticleTags;
            blog.Body = result.ArticleBody;
            return blog;
        }

        public void InsertArticleComment(InsertCommentViewModel model)
        {
            CommentArticleEntity comment=new CommentArticleEntity();
            comment.ArticleId = model.ArticleId;
            comment.CreateTime=DateTime.Now;
            comment.Show = false;
            comment.UserId = model.UserId;
            comment.CommentBody = model.CommentBody;
            _commentArticle.InsertCommentArticle(comment);
        }

        public void InsertFoodComment(InsertFoodCommentViewModel model)
        {
            CommentFoodEntity comment = new CommentFoodEntity();
            comment.FoodId = model.FoodId;
            comment.CreateTime = DateTime.Now;
            comment.Show = false;
            comment.UserId = model.UserId;
          
            comment.CommentText = model.CommentBody;
            _commentFood.InsertCommentFood(comment);
        }

        public Tuple<List<FoodCartViewModel>, int, int> GetFoods(string search,string meal, string sickness, string calories, string carbohydrate, string fat, string protein, int page)
        {
            List<FoodCartViewModel> food = new List<FoodCartViewModel>();
            IEnumerable<FoodEntity> list;
            int count;
            int pageSelected = page; int pageSkip = (page - 1) * 10;
            if (string.IsNullOrEmpty(meal) &&
                string.IsNullOrEmpty(sickness) &&
                !string.IsNullOrEmpty(carbohydrate) &&
                !string.IsNullOrEmpty(calories) &&
                !string.IsNullOrEmpty(fat) &&
                !string.IsNullOrEmpty(protein))
            {
                count = _home.CountGetFoodsWithFilter(calories, carbohydrate, fat, protein).PageCount(10);
                list = _home.GetFoodsWithFilter(calories, carbohydrate, fat, protein,pageSkip).Result;
            }else if(string.IsNullOrEmpty(meal) &&
                     !string.IsNullOrEmpty(sickness) &&
                     !string.IsNullOrEmpty(carbohydrate) &&
                     !string.IsNullOrEmpty(calories) &&
                     !string.IsNullOrEmpty(fat) &&
                     !string.IsNullOrEmpty(protein))

            {
                count = _home.CountGetFoodsWithSicknessAndFilter(sickness,calories, carbohydrate, fat, protein).PageCount(10);
                list = _home.GetFoodsWithSicknessAndFilter(sickness,calories, carbohydrate, fat, protein, pageSkip).Result;

            }
            else if (
                !string.IsNullOrEmpty(meal) &&
                string.IsNullOrEmpty(sickness) &&
                !string.IsNullOrEmpty(carbohydrate) &&
                !string.IsNullOrEmpty(calories) &&
                !string.IsNullOrEmpty(fat) &&
                !string.IsNullOrEmpty(protein)
            )
            {
                count = _home.CountGetFoodsWithMealAndFilter(meal, calories, carbohydrate, fat, protein).PageCount(10);
                list = _home.GetFoodsWithMealAndFilter(meal, calories, carbohydrate, fat, protein, pageSkip).Result;

            }
            else if(
                !string.IsNullOrEmpty(meal) &&
                !string.IsNullOrEmpty(sickness) &&
                string.IsNullOrEmpty(carbohydrate) &&
               string.IsNullOrEmpty(calories) &&
                string.IsNullOrEmpty(fat) &&
                string.IsNullOrEmpty(protein))
            {
                count = _home.CountGetFoodsWithMealAndSickness(meal, sickness).PageCount(10);
                list = _home.GetFoodsWithMealAndSickness(meal, sickness,  pageSkip).Result;

            }
            else if (!string.IsNullOrEmpty(meal) &&
                      string.IsNullOrEmpty(sickness) &&
                      string.IsNullOrEmpty(carbohydrate) &&
                      string.IsNullOrEmpty(calories) &&
                      string.IsNullOrEmpty(fat) &&
                      string.IsNullOrEmpty(protein))
            {
                count = _home.CountGetFoodsWithMeal(meal).PageCount(10);
                list = _home.GetFoodsWithMeal(meal, pageSkip).Result;

            }
            else if(string.IsNullOrEmpty(meal) &&
                    !string.IsNullOrEmpty(sickness) &&
                    string.IsNullOrEmpty(carbohydrate) &&
                    string.IsNullOrEmpty(calories) &&
                    string.IsNullOrEmpty(fat) &&
                    string.IsNullOrEmpty(protein))
            {
                count = _home.CountGetFoodsWithSickness(sickness).PageCount(10);
                list = _home.GetFoodsWithSickness(sickness, pageSkip).Result;

            }
            else if (
                !string.IsNullOrEmpty(meal) &&
                !string.IsNullOrEmpty(sickness) &&
                !string.IsNullOrEmpty(carbohydrate) &&
                !string.IsNullOrEmpty(calories) &&
                !string.IsNullOrEmpty(fat) &&
                !string.IsNullOrEmpty(protein))
            {
                count = _home.CountGetFoodsFilter(meal,sickness, calories, carbohydrate, fat, protein).PageCount(10); 
                list = _home.GetFoodsFilter(meal, sickness,calories, carbohydrate, fat, protein, pageSkip).Result;

            }
            else
            {
                count = _home.CountFood().PageCount(10); 
                list = _home.GetFoods(search,pageSkip).Result;

            }

            foreach (var item in list)
            {
                  food.Add(new FoodCartViewModel()
                  {
                      Category = item.Sickness.SicknessTitle,
                      FoodImage = item.FoodImage,
                      FoodDiscountPrice = item.FoodDiscountPrice,
                      FoodPrice = item.FoodPrice,
                      FoodTitle = item.FoodTitle,
                      FoodId = item.FoodId,
                      Rate = item.Rate
                  });
            }
            return Tuple.Create(food, count, pageSelected);
        }

        public Tuple<FoodDetailViewModel, List<FoodImageViewModel>, List<FoodPropertyViewModel>> GetFoodDetail(string id)
        {
            var result =  _home.GetFoodById(id).Result;
            FoodDetailViewModel food=new FoodDetailViewModel();
            food.Count =Convert.ToInt32(result.FoodCount);
            food.Category = result.Sickness.SicknessTitle;
            food.Summary = result.FoodSummary;
            food.Title = result.FoodTitle;
            food.Rate = result.Rate;
            food.Id = result.FoodId;
            food.Body = result.FoodDescription;
            food.Tags = result.FoodTags;
            food.Code = result.FoodCode;
            food.DiscountPrice = result.FoodDiscountPrice.ToString();
            food.Link = result.FoodLink;
            food.Price = result.FoodPrice.ToString();
            food.FoodProtein = result.FoodProtein;
            food.FoodCarbohydrate = result.FoodCarbohydrate;
            food.FoodCalories = result.FoodCalories;
            food.FoodFat = result.FoodFat;
            var gallery = _home.GetGallery(id).Result;
            List<FoodImageViewModel>images=new List<FoodImageViewModel>();
            foreach (var item in gallery)
            {
                images.Add(new FoodImageViewModel()
                {
                    ImagePath = item.ImagePath,
                    ImageId = item.ImageId
                });
            }
            images.Add(new FoodImageViewModel()
            {
                ImageId = result.SicknessId,
                ImagePath = result.FoodImage
            });
            List<FoodPropertyViewModel>foodProperty=new List<FoodPropertyViewModel>();
            var properties = _home.GetProperty(id).Result;
            foreach (var item in properties)
            {
                foodProperty.Add(new FoodPropertyViewModel()
                {
                    Value = item.PropertyValue,
                    Title = item.PropertyTitle
                });
            }

            return Tuple.Create(food, images, foodProperty);
        }

        public async Task<List<FoodCartViewModel>> GetLastFoods()
        {
            var result = await _home.GetFoodTen();
            List<FoodCartViewModel>card=new List<FoodCartViewModel>();
            foreach (var item in result)
            {
                card.Add(new FoodCartViewModel()
                {
                    Category = item.Sickness.SicknessTitle,
                    FoodImage = item.FoodImage,
                    FoodDiscountPrice = item.FoodDiscountPrice,
                    FoodPrice = item.FoodPrice,
                    FoodTitle = item.FoodTitle,
                    FoodId = item.FoodId,
                    Rate = item.Rate
                });
            }

            return card;
        }

        public async Task<List<BlogViewModel>> GetFourArticle()
        {
            var result = await _home.GetFourArticle();
            List<BlogViewModel>blog=new List<BlogViewModel>();
            foreach (var item in result)
            {
                blog.Add(new BlogViewModel()
                {
                    ImagePath = item.ArticleImage,
                    BlogId = item.ArticleId,
                    Category = item.Category.CategoryTitle,
                    Summary = item.Summary,
                    CreateTime = item.CreatedTime.SolarYear(),
                    Time = item.TimeStudy,
                    Title = item.ArticleTitle
                });
            }

            return blog;
        }

        public void AddToCart(AddToCardViewModel model)
        {
            var food = _food.GetFoodById(model.FoodId).Result;
            var order = _order.GetOrderByUserId(model.UserId).Result;
            if (order!=null)
            {
                var detailExist = _order.GetExistOrderDetail(order.OrderId, model.FoodId).Result;
                if (detailExist != null)
                {
                    detailExist.Count = detailExist.Count+1;
                    detailExist.Price = detailExist.Price + detailExist.Price;
                    _order.UpdateOrderDetail(detailExist);
                }
                else
                {
                    OrderDetailEntity detail = new OrderDetailEntity();
                    detail.Count = 1;
                    detail.FoodId = model.FoodId;
                    detail.OrderId = order.OrderId;

                    if (food.FoodDiscountPrice != 0)
                    {
                        detail.Price = food.FoodDiscountPrice;
                    }
                    else
                    {
                        detail.Price = food.FoodPrice;
                    }
                    _order.InsertOrderDetail(detail);
                }
            }
            else
            {
                Random random = new Random();
                OrderEntity newOrder=new OrderEntity();
                newOrder.UserId = model.UserId;
                newOrder.Condition = ConditionEnum.Open;
                newOrder.Close = false;
                newOrder.DateTime=DateTime.Now;
                newOrder.Code= random.Next(9999, 99999).ToString();
                _order.InsertOrder(newOrder);
                OrderDetailEntity detail = new OrderDetailEntity();
                detail.Count = 1;
                detail.FoodId = model.FoodId;
                detail.OrderId = newOrder.OrderId;

                if (food.FoodDiscountPrice != 0)
                {
                    detail.Price = food.FoodDiscountPrice;
                }
                else
                {
                    detail.Price = food.FoodPrice;
                }
                _order.InsertOrderDetail(detail);
            }
        }

        public Tuple<List<CartItemViewModel>, CartDetailViewModel> GetCart(string user)
        {
            var send = _profile.SenPrice().Result;
            var userAddress = _profile.GetAddress(user).Result;
            CartDetailViewModel detailCart = new CartDetailViewModel();
            List<CartItemViewModel> cartItem = new List<CartItemViewModel>();
            var userInfo = _user.GetMedicalInformation(user).Result;
            var order = _order.GetOrderByUserId(user).Result;
            if (order != null)
            {
                var items = _order.GetDetailById(order.OrderId).Result;
                var list = items as OrderDetailEntity[] ?? items.ToArray();
                foreach (var food in list)
                {
                    CartItemViewModel item = new CartItemViewModel();
                    item.FoodImage = food.Food.FoodImage;
                    item.FoodPrice = food.Price.ToString();
                    item.FoodTitle = food.Food.FoodTitle;
                    item.FoodId = food.FoodId;
                    item.FoodCount = food.Count.ToString();
                    item.DetailId = food.OrderDetailId;
                    if (userInfo.UserCarbohydrate == food.Food.FoodCarbohydrate &&
                        userInfo.UserCalories == food.Food.FoodCalories &&
                        userInfo.UserFat == food.Food.FoodFat &&
                        userInfo.UserProtein == food.Food.FoodProtein)
                    {
                        item.Healthy = 1; //Good
                    }
                    else
                    {
                        item.Healthy = 2; //Bad
                    }

                    cartItem.Add(item);
                }

                detailCart.City = userAddress.City.CityName;
                detailCart.State = userAddress.State.StateName;
                detailCart.SendPrice = send;
                detailCart.Seller = _profile.FullName(user).Result;
                detailCart.Total = list.Sum(s => s.Price).ToString();
                detailCart.TotalCart = Convert.ToInt32(send) + list.Sum(s => s.Price);
            }

            else
            {
                detailCart.City = userAddress.City.CityName;
                detailCart.State = userAddress.State.StateName;
                detailCart.SendPrice = send;
                detailCart.Seller = _profile.FullName(user).Result;
                detailCart.Total = "";
                detailCart.TotalCart = 0;
            }

            return Tuple.Create(cartItem, detailCart);
        }

        public void RemoveOrderDetail(string id)
        {
            var orderDetail = _order.GetById(id).Result;
            if (orderDetail.Count ==1)
            {
                _order.DeleteOrderDetail(orderDetail);
            }
            else if(orderDetail.Count>1)
            {
                orderDetail.Count = orderDetail.Count-1;
                _order.UpdateOrderDetail(orderDetail);
            }
          
        }

        public async Task<List<UserQuestionViewModel>> Questions()
        {
           List<UserQuestionViewModel>question=new List<UserQuestionViewModel>();
           var result = await _home.UserQuestions();
           foreach (var item in result)
           {
               question.Add(new UserQuestionViewModel()
               {
                   UserFullName = item.User.UserFullName,
                   Body = item.UserQuestionBody,
                   Id = item.UserQuestionId,
                   Time = item.CreateTime.SolarYear(),
                   Title = item.UserQuestionTitle
               });
           }

           return question;
        }

        public async Task<List<UserAnswerViewModel>> Answer(string id)
        {
            var result = await _home.GetAnswer(id);
            List<UserAnswerViewModel>answer=new List<UserAnswerViewModel>();
            foreach (var item in result)
            {
                answer.Add(new UserAnswerViewModel()
                {
                    Avatar = item.User.UserAvatar,
                    Body = item.UserAnswerBody,
                    Time = item.Time.SolarYear(),
                    UserName = item.User.UserFullName
                });
            }

            return answer;
        }

        public void InsertAnswer(InsertUserAnswerViewModel model)
        {
            UserAnswerEntity answer=new UserAnswerEntity();
            answer.Time=DateTime.Now;
            answer.QuestionId = model.Id;
            answer.UserId = model.UserId;
            answer.UserAnswerBody = model.Body;
            _home.InsertAnswer(answer);
        }
        public void Insert(ContactViewModel model)
        {
            ContactEntity contact = new ContactEntity();
            contact.Time = DateTime.Now;
            contact.Body = model.Body;
            contact.Mail = model.Mail;
            contact.Name = model.Name;
            contact.PhoneNumber = model.PhoneNumber;
            _contact.Insert(contact);
        }
        public void InsertQuestion(InsertUserQuestionViewModel model)
        {
            UserQuestionEntity question=new UserQuestionEntity();
            question.UserId = model.UserId;
            question.CreateTime=DateTime.Now;
            question.UserQuestionBody = model.Body;
            question.UserQuestionTitle = model.Title;
            question.Accept = false;
            _home.InsertQuestion(question);
        }
    }
}
