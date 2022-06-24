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
using Application.ViewModel.Home.ImmediateOrder;
using Application.ViewModel.Home.Profile;
using Domin.Entities;
using Domin.Enum;
using Domin.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Service.Repository
{
    public class HomeService : IHomeService
    {
        private readonly IHomeInterface _home;
        private readonly ICommentArticleInterface _commentArticle;
        private readonly IOrderInterface _order;
        private readonly ICommentFoodInterface _commentFood;
        private readonly IFoodInterface _food;
        private readonly IUserInterface _user;
        private readonly IProfileInterface _profile;
        private readonly ITableInterface _table;
        private readonly IContactInterface _contact;
        private readonly IMailInterface _mail;
        private readonly ISupporterInterface _supporter;
        private readonly ISettingInterface _setting;
        private readonly IGeneralInterface _general;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IFilterInterface _filter;

        public HomeService(IHomeInterface home, ICommentArticleInterface commentArticle, IOrderInterface order, ICommentFoodInterface commentFood, IFoodInterface food, IUserInterface user, IProfileInterface profile, ITableInterface table, IContactInterface contact, IMailInterface mail, ISupporterInterface supporter, ISettingInterface setting, IGeneralInterface general, UserManager<UserEntity> userManager, IFilterInterface filter)
        {
            _home = home;
            _commentArticle = commentArticle;
            _order = order;
            _commentFood = commentFood;
            _food = food;
            _user = user;
            _profile = profile;
            _table = table;
            _contact = contact;
            _mail = mail;
            _supporter = supporter;
            _setting = setting;
            _general = general;
            _userManager = userManager;
            _filter = filter;
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
                list = _home.GetArticles(search, pageSkip).Result;
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
            BlogDetailViewModel blog = new BlogDetailViewModel();
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
            CommentArticleEntity comment = new CommentArticleEntity();
            comment.ArticleId = model.ArticleId;
            comment.CreateTime = DateTime.Now;
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



        public Tuple<List<FoodCartViewModel>, int, int> GetFoods(string search, string meal, string sickness,
            int calories, string carbohydrate, string fat, string protein, int page, string activeUser)
        {
            List<FoodCartViewModel> food = new List<FoodCartViewModel>();
            IEnumerable<FoodEntity> list;
            int count;
            int pageSelected = page;
            int pageSkip = (page - 1) * 10;
            if (!string.IsNullOrEmpty(search))
            {
                count = _filter.CountFood().PageCount(10);
                list = _filter.GetFoods(search, pageSkip).Result;
            }

            if (!string.IsNullOrEmpty(activeUser))
            {
                var medical = _user.GetMedicalInformation(activeUser).Result;

                if (medical != null)
                {
                    if (carbohydrate != null && calories != 0 && fat != null && protein != null)
                    {
                        if (calories <= Convert.ToInt32(medical.UserCalories) &&
                            carbohydrate == medical.UserCarbohydrate && fat == medical.UserFat &&
                            protein == medical.UserProtein)
                        {
                            if (meal != null)
                            {
                                count = _filter.CountGetFoodsFilter(meal,medical.SicknessId,calories,carbohydrate,fat,protein).PageCount(10);
                                list = _filter.GetFoodsFilter(meal, medical.SicknessId, calories, carbohydrate, fat, protein, pageSkip).Result;
                            }
                            else
                            {
                                count = _filter.CountGetFoodsWithSicknessAndFilter(medical.SicknessId, calories, carbohydrate, fat, protein).PageCount(10);
                                list = _filter.GetFoodsWithSicknessAndFilter( medical.SicknessId, calories, carbohydrate, fat, protein, pageSkip).Result;

                            }
                        }
                        else
                        {
                            if (meal != null)
                            {
                                count = _filter.CountGetFoodsFilter(meal, medical.SicknessId, Convert.ToInt32(medical.UserCalories), medical.UserCarbohydrate, medical.UserFat, medical.UserProtein).PageCount(10);
                                list = _filter.GetFoodsFilter(meal, medical.SicknessId, Convert.ToInt32(medical.UserCalories), medical.UserCarbohydrate, medical.UserFat, medical.UserProtein, pageSkip).Result;
                            }
                            else
                            {
                                count = _filter.CountGetFoodsWithSicknessAndFilter(medical.SicknessId, Convert.ToInt32(medical.UserCalories), medical.UserCarbohydrate, medical.UserFat, medical.UserProtein).PageCount(10);
                                list = _filter.GetFoodsWithSicknessAndFilter(medical.SicknessId, Convert.ToInt32(medical.UserCalories), medical.UserCarbohydrate, medical.UserFat, medical.UserProtein, pageSkip).Result;

                            }
                        }
                    }
                    else
                    {
                        if (meal != null)
                        {
                            count = _filter.CountGetFoodsFilter(meal, medical.SicknessId, Convert.ToInt32(medical.UserCalories), medical.UserCarbohydrate, medical.UserFat, medical.UserProtein).PageCount(10);
                            list = _filter.GetFoodsFilter(meal, medical.SicknessId, Convert.ToInt32(medical.UserCalories), medical.UserCarbohydrate, medical.UserFat, medical.UserProtein, pageSkip).Result;
                        }
                        else
                        {
                            count = _filter.CountGetFoodsWithSicknessAndFilter(medical.SicknessId, Convert.ToInt32(medical.UserCalories), medical.UserCarbohydrate, medical.UserFat, medical.UserProtein).PageCount(10);
                            list = _filter.GetFoodsWithSicknessAndFilter(medical.SicknessId, Convert.ToInt32(medical.UserCalories), medical.UserCarbohydrate, medical.UserFat, medical.UserProtein, pageSkip).Result;

                        }
                    }
                }
                else
                {
                    if (carbohydrate != null && calories != 0 && fat != null && protein != null)
                    {
                        if (meal != null && sickness != null)
                        {
                            count = _filter.CountGetFoodsFilter(meal, sickness, calories, carbohydrate, fat, protein).PageCount(10);
                            list = _filter.GetFoodsFilter(meal, sickness, calories, carbohydrate, fat, protein, pageSkip).Result;
                        }
                        else if (meal == null && sickness != null)
                        {
                            count = _filter.CountGetFoodsWithSicknessAndFilter(sickness, calories, carbohydrate, fat, protein).PageCount(10);
                            list = _filter.GetFoodsWithSicknessAndFilter(sickness, calories, carbohydrate, fat, protein, pageSkip).Result;
                        }
                        else if (sickness == null && meal != null)
                        {
                            count = _filter.CountGetFoodsWithMealAndFilter(meal, calories, carbohydrate, fat, protein).PageCount(10);
                            list = _filter.GetFoodsWithMealAndFilter(meal, calories, carbohydrate, fat, protein, pageSkip).Result;
                        }
                        else
                        {
                            count = _filter.CountGetFoodsWithFilter(calories, carbohydrate, fat, protein).PageCount(10);
                            list = _filter.GetFoodsWithFilter(calories, carbohydrate, fat, protein, pageSkip).Result;
                        }
                    }
                    else
                    {
                        if (meal != null && sickness != null)
                        {
                            count = _filter.CountGetFoodsWithMealAndSickness(meal, sickness).PageCount(10);
                            list = _filter.GetFoodsWithMealAndSickness(meal, sickness, pageSkip).Result;
                        }
                        else if (meal == null && sickness != null)
                        {
                            count = _filter.CountGetFoodsWithSickness(sickness).PageCount(10);
                            list = _filter.GetFoodsWithSickness(sickness, pageSkip).Result;
                        }
                        else if (sickness == null && meal != null)
                        {
                            count = _filter.CountGetFoodsWithMeal(meal).PageCount(10);
                            list = _filter.GetFoodsWithMeal(meal, pageSkip).Result;
                        }
                        else
                        {
                            count = _filter.CountFood().PageCount(10);
                            list = _filter.GetFoods(search, pageSkip).Result;
                        }
                    }
                }

            }
            else
            {
                if (carbohydrate != null && calories != 0 && fat != null && protein != null)
                {
                    if (meal != null && sickness != null)
                    {
                        count = _filter.CountGetFoodsFilter(meal, sickness,calories,carbohydrate,fat,protein).PageCount(10);
                        list = _filter.GetFoodsFilter(meal, sickness, calories, carbohydrate, fat, protein, pageSkip).Result;
                    }
                    else if (meal == null && sickness != null)
                    {
                        count = _filter.CountGetFoodsWithSicknessAndFilter(sickness, calories, carbohydrate, fat, protein).PageCount(10);
                        list = _filter.GetFoodsWithSicknessAndFilter(sickness, calories, carbohydrate, fat, protein, pageSkip).Result;
                    }
                    else if (sickness == null && meal != null)
                    {
                        count = _filter.CountGetFoodsWithMealAndFilter(meal, calories, carbohydrate, fat, protein).PageCount(10);
                        list = _filter.GetFoodsWithMealAndFilter(meal, calories, carbohydrate, fat, protein, pageSkip).Result;
                    }
                    else
                    {
                        count = _filter.CountGetFoodsWithFilter(calories, carbohydrate, fat, protein).PageCount(10);
                        list = _filter.GetFoodsWithFilter(calories, carbohydrate, fat, protein, pageSkip).Result;
                    }
                }
                else
                {
                    if (meal != null && sickness != null)
                    {
                        count = _filter.CountGetFoodsWithMealAndSickness(meal, sickness).PageCount(10);
                        list = _filter.GetFoodsWithMealAndSickness(meal, sickness, pageSkip).Result;
                    }
                    else if (meal == null && sickness != null)
                    {
                        count = _filter.CountGetFoodsWithSickness(sickness).PageCount(10);
                        list = _filter.GetFoodsWithSickness(sickness, pageSkip).Result;
                    }
                    else if (sickness == null && meal != null)
                    {
                        count = _filter.CountGetFoodsWithMeal(meal).PageCount(10);
                        list = _filter.GetFoodsWithMeal(meal, pageSkip).Result;
                    }
                    else
                    {
                        count = _filter.CountFood().PageCount(10);
                        list = _filter.GetFoods(search, pageSkip).Result;
                    }
                }
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

        public Tuple<FoodDetailViewModel, List<FoodImageViewModel>, List<FoodPropertyViewModel>>
            GetFoodDetail(string id)
        {
            var result = _home.GetFoodById(id).Result;
            FoodDetailViewModel food = new FoodDetailViewModel();
            food.Count = Convert.ToInt32(result.FoodCount);
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
            food.FoodCalories = result.FoodCalories.ToString();
            food.FoodFat = result.FoodFat;
            var gallery = _home.GetGallery(id).Result;
            List<FoodImageViewModel> images = new List<FoodImageViewModel>();
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
            List<FoodPropertyViewModel> foodProperty = new List<FoodPropertyViewModel>();
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
            List<FoodCartViewModel> card = new List<FoodCartViewModel>();
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
            List<BlogViewModel> blog = new List<BlogViewModel>();
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
            if (order != null)
            {
                var detailExist = _order.GetExistOrderDetail(order.OrderId, model.FoodId).Result;
                if (detailExist != null)
                {
                    detailExist.Count = detailExist.Count + 1;
                    detailExist.Price = detailExist.Price + detailExist.Price;
                    _order.UpdateOrderDetail(detailExist);
                    order.Total = order.Total + detailExist.Price;
                    _order.UpdateOrder(order);
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
                        order.Total = order.Total + food.FoodDiscountPrice;
                    }
                    else
                    {
                        detail.Price = food.FoodPrice;
                        order.Total = order.Total + food.FoodPrice;
                    }

                    _order.UpdateOrder(order);
                    _order.InsertOrderDetail(detail);
                }
            }
            else
            {
                Random random = new Random();
                OrderEntity newOrder = new OrderEntity();
                newOrder.UserId = model.UserId;
                newOrder.Condition = ConditionEnum.Open;
                newOrder.Close = false;
                newOrder.DateTime = DateTime.Now;
                newOrder.Code = random.Next(9999, 99999).ToString();
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
                var orderNew = _order.GetOrderById(newOrder.OrderId).Result;
                orderNew.Total = orderNew.Total + detail.Price;
                _order.UpdateOrder(orderNew);
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
                        userInfo.UserCalories == food.Food.FoodCalories.ToString() &&
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

                if (userAddress != null)
                {
                    detailCart.City = userAddress.City.CityName;
                    detailCart.State = userAddress.State.StateName;
                }
                else
                {
                    detailCart.City = "وارد نشده";
                    detailCart.State = "وارد نشده";
                }

                detailCart.SendPrice = send;
                detailCart.Seller = _profile.FullName(user).Result;
                detailCart.Total = order.Total.ToString("#,0");
                detailCart.TotalCart = Convert.ToInt32(send) + order.Total;
            }

            else
            {
                if (userAddress != null)
                {
                    detailCart.City = userAddress.City.CityName;
                    detailCart.State = userAddress.State.StateName;
                }
                else
                {
                    detailCart.City = "وارد نشده";
                    detailCart.State = "وارد نشده";
                }

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
            if (orderDetail.Count == 1)
            {
                _order.DeleteOrderDetail(orderDetail);
            }
            else if (orderDetail.Count > 1)
            {
                orderDetail.Count = orderDetail.Count - 1;
                _order.UpdateOrderDetail(orderDetail);
            }

        }

        public async Task<List<UserQuestionViewModel>> Questions()
        {
            List<UserQuestionViewModel> question = new List<UserQuestionViewModel>();
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
            List<UserAnswerViewModel> answer = new List<UserAnswerViewModel>();
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
            UserAnswerEntity answer = new UserAnswerEntity();
            answer.Time = DateTime.Now;
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

        public void AddMail(AddMailViewModel model)
        {
            MailEntity entity = new MailEntity();
            entity.Mail = model.Mail;
            _mail.Insert(entity);
        }

        public Tuple<TableRowViewModel, List<TableColumnViewModel>> GetTableById(string id)
        {
            var result = _table.GetRowById(id).Result;
            TableRowViewModel table = new TableRowViewModel();
            if (result.Count != 0)
            {
                table.Row = result.Rows.Split("-");
            }
            else
            {
                table.Row = null;
            }

            table.Description = result.Description;
            table.Name = result.TableName;
            var list = _table.GetColumns(id).Result;
            List<TableColumnViewModel> column = new List<TableColumnViewModel>();
            foreach (var item in list)
            {
                TableColumnViewModel test = new TableColumnViewModel();
                if (string.IsNullOrEmpty(item.Columns))
                {
                    test.Column = null;
                }
                else
                {
                    test.Column = item.Columns.Split("-");
                }

                column.Add(test);
            }

            return Tuple.Create(table, column);
        }

        public async Task<SupporterDetailViewModel> GetSupporterById(string id)
        {
            var result = await _supporter.GetSupporterById(id);
            SupporterDetailViewModel detail = new SupporterDetailViewModel();
            detail.SupporterName = result.SupporterName;
            detail.SupporterImagePath = result.SupporterImage;
            detail.SupporterActivity = result.SupporterActivity;
            detail.SupporterNumber = result.SupporterNumber;
            detail.SupporterMail = result.SupporterMail;
            detail.SupporterDescription = result.SupporterDescription;
            detail.SupporterAddress = result.SupporterAddress;
            detail.SupporterId = result.SupporterId;
            return detail;
        }

        public async Task<LawViewModel> GetLaw()
        {
            var result = await _setting.GetSetting();
            LawViewModel law = new LawViewModel()
            {
                Text = result.Law
            };
            return law;
        }

        public async Task<string> CreateChatGroup(string connection)
        {
            return await _general.CreateChatGroup(connection);
        }

        public async Task<string> GetChatGroupKey(string connection)
        {
            return await _general.GetChatGroupKey(connection);
        }

        public void InsertChatMessage(InsertChatMessageViewModel model)
        {
            ChatMessageEntity chat = new ChatMessageEntity();
            chat.Time = DateTime.Now;
            chat.ChatId = model.GroupKey;
            chat.Sender = model.Sender;
            chat.Text = model.Message;
            _general.SaveMessage(chat);
        }

        public async Task<List<SelectFoodViewModel>> GetFoodForce(SelectDayAndMealViewModel model)
        {
            IEnumerable<FoodEntity> foodEntities;
            List<SelectFoodViewModel> foods = new List<SelectFoodViewModel>();
            if (model.Person != "2")
            {
                var medical = await _user.GetMedicalInformation(model.Person);
                var calories = Convert.ToInt32(medical.UserCalories);
                var week = ConvertEnum.ChangeWeekEnum(model.Week);
                foodEntities = await _home.GetFoodForce(model.Meal, medical.SicknessId, calories,
                    medical.UserCarbohydrate, medical.UserFat, medical.UserProtein, week);

            }
            else
            {
                var calories = Convert.ToInt32(model.FoodCalories);
                var week = ConvertEnum.ChangeWeekEnum(model.Week);
                foodEntities = await _home.GetFoodForce(model.Meal, model.SicknessId, calories,
                    model.FoodCarbohydrate, model.FoodFat, model.FoodProtein, week);
            }

            foreach (var item in foodEntities)
            {
                foods.Add(new SelectFoodViewModel()
                {
                    FoodId = item.FoodId,
                    FoodName = item.FoodTitle,
                    FoodPrice = item.FoodPrice.ToString("#,0"),
                    FoodImage = item.FoodImage,
                    FoodCarbohydrate = item.FoodCarbohydrate,
                    FoodFat = item.FoodFat,
                    FoodProtein = item.FoodProtein,
                    FoodCalories = item.FoodCalories
                });
            }

            return foods;
        }

        public void FoodForceAddCard(List<string> foods, string userId, bool me)
        {

            var order = _order.GetOrderByUserId(userId).Result;
            if (order != null)
            {
                foreach (var item in foods)
                {
                    var food = _food.GetFoodById(item).Result;
                    var detailExist = _order.GetExistOrderDetail(order.OrderId, item).Result;
                    if (detailExist != null)
                    {
                        detailExist.Count = detailExist.Count + 1;
                        detailExist.Me = me;
                        detailExist.Price = detailExist.Price + detailExist.Price;
                        _order.UpdateOrderDetail(detailExist);
                        order.Total = order.Total + detailExist.Price;
                        _order.UpdateOrder(order);
                    }
                    else
                    {
                        OrderDetailEntity detail = new OrderDetailEntity();
                        detail.Count = 1;
                        detail.FoodId = item;
                        detail.OrderId = order.OrderId;
                        detail.Me = me;
                        if (food.FoodDiscountPrice != 0)
                        {
                            detail.Price = food.FoodDiscountPrice;
                        }
                        else
                        {
                            detail.Price = food.FoodPrice;
                        }

                        _order.InsertOrderDetail(detail);
                        order.Total = order.Total + detail.Price;
                        _order.UpdateOrder(order);

                    }
                }
            }
            else
            {
                Random random = new Random();
                OrderEntity newOrder = new OrderEntity();
                newOrder.UserId = userId;
                newOrder.Condition = ConditionEnum.Open;
                newOrder.Close = false;
                newOrder.DateTime = DateTime.Now;
                newOrder.Code = random.Next(9999, 99999).ToString();
                _order.InsertOrder(newOrder);
                foreach (var itemFood in foods)
                {
                    var foodItem = _food.GetFoodById(itemFood).Result;
                    OrderDetailEntity detail = new OrderDetailEntity();
                    detail.Count = 1;
                    detail.FoodId = itemFood;
                    detail.Me = me;
                    detail.OrderId = newOrder.OrderId;

                    if (foodItem.FoodDiscountPrice != 0)
                    {
                        detail.Price = foodItem.FoodDiscountPrice;
                    }
                    else
                    {
                        detail.Price = foodItem.FoodPrice;
                    }

                    _order.InsertOrderDetail(detail);
                    var orderNew = _order.GetOrderById(newOrder.OrderId).Result;
                    orderNew.Total = orderNew.Total + detail.Price;
                    _order.UpdateOrder(orderNew);
                }
            }
        }

        public async Task<UserAddressViewModel> GetCardAddress(string user)
        {
            var order = _order.GetOrderByUserId(user).Result;
            var detail = await _order.GetDetailById(order.OrderId);
            var userInfo = await _userManager.FindByIdAsync(user);
            var address = await _profile.GetAddress(user);
            UserAddressViewModel model = new UserAddressViewModel();
            model.City = address.City.CityName;
            model.State = address.State.StateName;
            model.AddressCode = address.AddressCode;
            model.AddressText = address.AddressText;
            model.Send = _profile.SenPrice().Result;
            model.PhoneNumber = userInfo.PhoneNumber;
            model.Mail = userInfo.Email;
            model.Total = order.Total.ToString("#,0");
            return model;
        }

        public async Task<bool> ExistAddress(string user)
        {
            return await _profile.ExistAddress(user);
        }


        public void InsertQuestion(InsertUserQuestionViewModel model)
        {
            UserQuestionEntity question = new UserQuestionEntity();
            question.UserId = model.UserId;
            question.CreateTime = DateTime.Now;
            question.UserQuestionBody = model.Body;
            question.UserQuestionTitle = model.Title;
            question.Accept = false;
            _home.InsertQuestion(question);
        }
    }
}
//}
//if (meal != null || sickness != null || calories != 0 || carbohydrate != null || fat != null ||
//         protein != null)
//{
//    if (!string.IsNullOrEmpty(activeUser))
//    {
//        var medical = _user.GetMedicalInformation(activeUser).Result;
//        if (medical != null)
//        {
//            if (Convert.ToInt32(carbohydrate) <= Convert.ToInt32(medical.UserCarbohydrate) ||
//                Convert.ToInt32(calories) <= Convert.ToInt32(medical.UserCalories) ||
//                Convert.ToInt32(protein) <= Convert.ToInt32(medical.UserProtein) ||
//                Convert.ToInt32(fat) <= Convert.ToInt32(medical.UserFat))
//            {

//                count = _home
//                    .CountGetFoodsFilter(meal, medical.SicknessId, calories, carbohydrate, fat, protein)
//                    .PageCount(10);
//                list = _home.GetFoodsFilter(meal, medical.SicknessId, calories, carbohydrate, fat, protein,
//                    pageSkip).Result;

//            }
//            else
//            {

//                count = _home.CountGetFoodsFilter(meal, medical.SicknessId,
//                    Convert.ToInt32(medical.UserCalories), medical.UserCarbohydrate, medical.UserFat,
//                    medical.UserProtein).PageCount(10);
//                var c = Convert.ToInt32(medical.UserCalories);
//                list = _home.GetFoodsFilter(meal, medical.SicknessId, c,
//                    medical.UserCarbohydrate, medical.UserFat, medical.UserProtein, pageSkip).Result;

//            }
//        }
//        else
//        {
//            count = _home.CountGetFoodsFilter(meal, sickness, calories, carbohydrate, fat, protein)
//                .PageCount(10);
//            list = _home.GetFoodsFilter(meal, sickness, calories, carbohydrate, fat, protein, pageSkip)
//                .Result;
//        }
//    }
//    else
//    {

//        count = _home.CountGetFoodsFilter(meal, sickness, calories, carbohydrate, fat, protein)
//            .PageCount(10);
//        list = _home.GetFoodsFilter(meal, sickness, calories, carbohydrate, fat, protein, pageSkip).Result;

//    }

//}
//else
//{
//    if (!string.IsNullOrEmpty(activeUser))
//    {
//        var medical = _user.GetMedicalInformation(activeUser).Result;
//        if (medical != null)
//        {
//            count = _home.CountGetFoodsFilter(null, medical.SicknessId,
//                Convert.ToInt32(medical.UserCalories), medical.UserCarbohydrate, medical.UserFat,
//                medical.UserProtein).PageCount(10);
//            var b = Convert.ToInt32(medical.UserCalories);
//            list = _home.GetFoodsFilter(null, medical.SicknessId, b,
//                medical.UserCarbohydrate, medical.UserFat, medical.UserProtein, pageSkip).Result;
//        }
//        else
//        {
//            count = _home.CountFood().PageCount(10);
//            list = _home.GetFoods(search, pageSkip).Result;

//        }
//    }
//    else
//    {
//        count = _home.CountFood().PageCount(10);
//        list = _home.GetFoods(search, pageSkip).Result;
//    }
//}
