using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Food;
using Application.ViewModel.Selection;
using Application.ViewModel.Sickness;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class FoodService : IFoodService
    {
        private readonly IFoodInterface _food;

        private readonly IGeneralInterface _general;

        private readonly IGalleryInterface _gallery;
        private readonly ICommentFoodInterface _comment;

        public FoodService(IFoodInterface food, IGeneralInterface general, IGalleryInterface gallery, ICommentFoodInterface comment)
        {
            _food = food;
            _general = general;
            _gallery = gallery;
            _comment = comment;
        }
        public Tuple<List<FoodViewModel>, int, int> GetFoods(int page, string search = "")
        {
            int pageSelected = page;
            int count = _food.CountFood().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _food.GetFoods(search, pageSkip).Result;
            List<FoodViewModel> food = new List<FoodViewModel>();

            foreach (var item in list)
            {
                food.Add(new FoodViewModel()
                {
                    FoodPrice = item.FoodPrice.ToString("#,0"),
                    FoodTitle = item.FoodTitle,
                    FoodImage = item.FoodImage,
                    FoodCount = item.FoodCount,
                    FoodId = item.FoodId
                });
            }
            return Tuple.Create(food, count, pageSelected);
        }

        public async Task<UpdateFoodViewModel> GetFoodById(string id)
        {
            var result = await _food.GetFoodById(id);
            UpdateFoodViewModel food = new UpdateFoodViewModel();
            food.SicknessId = result.SicknessId;
            food.MealId = result.MealId;
            food.FoodPrice = result.FoodPrice.ToString();
            food.FoodTitle = result.FoodTitle;
            food.FoodImagePath = result.FoodImage;
            food.FoodCount = result.FoodCount;
            food.FoodSummary = result.FoodSummary;
            food.FoodLink = result.FoodLink;
            food.Rate = result.Rate;
            food.FoodCode = result.FoodCode;
            food.FoodDiscountPrice = result.FoodDiscountPrice.ToString();
            food.FoodCalories = result.FoodCalories;
            food.FoodCarbohydrate = result.FoodCarbohydrate;
            food.FoodDescription = result.FoodDescription;
            food.FoodFat = result.FoodFat;
            food.FoodId = result.FoodId;
            food.FoodTags = result.FoodTags;
            food.FoodProtein = result.FoodProtein;
            return food;
        }

        public bool InsertFood(InsertFoodViewModel model)
        {
            FoodEntity food = new FoodEntity();
            food.Time = DateTime.Now;
            food.SicknessId = model.SicknessId;
            food.MealId = model.MealId;
            food.FoodPrice = Convert.ToInt32(model.FoodPrice);
            food.FoodTitle = model.FoodTitle;
            food.FoodCount = model.FoodCount;
            food.FoodSummary = model.FoodSummary;
            food.FoodLink = model.FoodLink;
            food.Rate = model.Rate;
            food.FoodDiscountPrice =Convert.ToInt32(model.FoodDiscountPrice);
            food.FoodCalories = model.FoodCalories;
            food.FoodCarbohydrate = model.FoodCarbohydrate;
            food.FoodDescription = model.FoodDescription;
            food.FoodFat = model.FoodFat; food.FoodCode = model.FoodCode;
            food.FoodTags = model.FoodTags;
            food.FoodProtein = model.FoodProtein;
            if (model.FoodImage != null)
            {
                var check = model.FoodImage.IsImage();
                if (check)
                {
                    food.FoodImage = ImageProcessing.SaveImage(model.FoodImage);
                }
                else
                {
                    food.FoodImage = "notFound.png";
                }
            }
            else
            {
                food.FoodImage = "notFound.png";
            }
         
            try
            {
                _food.InsertFood(food);

                FoodSeoEntity entity = new FoodSeoEntity();
                entity.FoodId = food.FoodId;
                entity.Description = "";
                entity.GraphDescription = "";
                entity.GraphSiteName = "";
                entity.GraphTitle = "";
                entity.GraphUrl = "";
                entity.TwitterDescription = "";
                entity.TwitterTitle = "";
                entity.GraphImage = "noImage.jpg";
                entity.TwitterImage = "noImage.jpg";
                _food.Insert(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateFood(UpdateFoodViewModel model)
        {
            var food = _food.GetFoodById(model.FoodId).Result;
            food.SicknessId = model.SicknessId;
            food.MealId = model.MealId;
            food.FoodPrice = Convert.ToInt32(model.FoodPrice);
            food.FoodTitle = model.FoodTitle;
            food.FoodCount = model.FoodCount;
            food.FoodSummary = model.FoodSummary; food.FoodCode = model.FoodCode;
            food.FoodLink = model.FoodLink;
            food.FoodDiscountPrice = Convert.ToInt32(model.FoodDiscountPrice);
            food.FoodCalories = model.FoodCalories;
            food.FoodCarbohydrate = model.FoodCarbohydrate;
            food.FoodDescription = model.FoodDescription;
            food.FoodFat = model.FoodFat; food.Rate = model.Rate;
            food.FoodTags = model.FoodTags;
            food.FoodProtein = model.FoodProtein;
            if (model.FoodImage != null)
            {
                var check = model.FoodImage.IsImage();
                if (check)
                {
                    food.FoodImage = ImageProcessing.SaveImage(model.FoodImage);
                    if (model.FoodImagePath != "notFound.png")
                    {
                        ImageProcessing.RemoveImage(model.FoodImagePath);
                    }
                }
            }

            try
            {
                _food.UpdateFood(food);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFood(string id)
        {
            var model = _food.GetFoodById(id).Result;
            try
            {
                _food.DeleteFood(model);
                if (model.FoodImage != "notFound.png")
                {
                    ImageProcessing.RemoveImage(model.FoodImage);
                }

                var gallery = _gallery.GetGalleries(id).Result;
                foreach (var image in gallery)
                {
                    _gallery.DeleteGallery(image);
                }

                var seo = _food.GetSeo(id).Result;
                _food.DeleteSeo(seo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<SelectViewModel>> GetMeals()
        {
            var result = await _general.GetMeals();
            List<SelectViewModel>select=new List<SelectViewModel>();
            foreach (var item in result)
            {
                select.Add(new SelectViewModel()
                {
                    Text = item.MealTitle,
                    Value = item.MealId
                });
            }

            return select;
        }

        public async Task<List<SelectViewModel>> GetSickness()
        {
            var result = await _general.GetSickness();
            List<SelectViewModel> select = new List<SelectViewModel>();
            foreach (var item in result)
            {
                select.Add(new SelectViewModel()
                {
                    Text = item.SicknessTitle,
                    Value = item.SicknessId
                });
            }

            return select;
        }

        public async Task<FoodSeoViewModel> GetSeoViewModel(string id)
        {
            var seo = await _food.GetSeo(id);
            FoodSeoViewModel model = new FoodSeoViewModel();
            model.FoodId = seo.FoodId;
                model.GraphDescription = seo.GraphDescription;
                model.GraphSiteName = seo.GraphSiteName;
                model.GraphImagePath = seo.GraphImage;
                model.GraphTitle = seo.GraphTitle;
                model.GraphUrl = seo.GraphUrl;
                model.TwitterDescription = seo.TwitterDescription;
                model.TwitterImagePath = seo.TwitterImage;
                model.TwitterTitle = seo.TwitterTitle;
                model.Description = seo.Description;
                return model;
        }

        public void ChangeSeo(FoodSeoViewModel model)
        {
            var seo = _food.GetSeo(model.FoodId).Result;
          
                seo.FoodId = model.FoodId;
                seo.Description = model.Description;
                seo.GraphDescription = model.GraphDescription;
                seo.GraphSiteName = model.GraphSiteName;
                seo.GraphImage = model.GraphImagePath;
                seo.GraphTitle = model.GraphTitle;
                seo.GraphUrl = model.GraphUrl;
                seo.TwitterDescription = model.TwitterDescription;
                seo.TwitterImage = model.TwitterImagePath;
                seo.TwitterTitle = model.TwitterTitle;
                if (model.GraphImage != null)
                {
                    var checkImage = model.GraphImage.IsImage();
                    if (checkImage)
                    {
                        seo.GraphImage = ImageProcessing.SaveImage(model.GraphImage);
                        if (model.GraphImagePath != "noImage.jpg")
                        {
                            ImageProcessing.RemoveImage(model.GraphImagePath);
                        }

                    }
                }

                if (model.TwitterImage != null)
                {
                    var checkImage = model.TwitterImage.IsImage();
                    if (checkImage)
                    {
                        seo.TwitterImage = ImageProcessing.SaveImage(model.TwitterImage);
                        if (model.TwitterImagePath != "noImage.jpg")
                        {
                            ImageProcessing.RemoveImage(model.TwitterImagePath);
                        }

                    }
                }
                _food.Update(seo);
        }

        public Tuple<List<CommentFoodViewModel>, int, int> GetComment(string id, int page = 1, string search = "")
        {
            int pageSelected = page;
            int count = _comment.CountCommentFood(id).PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _comment.GetCommentFoods(id, search, pageSkip).Result;
            List<CommentFoodViewModel> comment = new List<CommentFoodViewModel>();

            foreach (var item in list)
            {
                comment.Add(new CommentFoodViewModel()
                {
                    Time = item.CreateTime.SolarYear(),
                    Avatar = item.User.UserAvatar,
                    FullName = item.User.UserFullName,
                    Id = item.CommentId
                });
            }
            return Tuple.Create(comment, count, pageSelected);
        }

        public async Task<CommentFoodDetailViewModel> GetCommentFoodDetail(string id)
        {
            var result = await _comment.GetCommentFoodById(id);
            CommentFoodDetailViewModel comment = new CommentFoodDetailViewModel();
            comment.Time = result.CreateTime.SolarYear();
            comment.Avatar = result.User.UserAvatar;
            comment.ParentId = result.FoodId;
            comment.Id = result.CommentId;
            comment.Body = result.CommentText;
            comment.Show = result.Show;
            comment.Name = result.User.UserFullName;
            return comment;
        }

        public void UpdateComment(CommentFoodDetailViewModel model)
        {
            var result = _comment.GetCommentFoodById(model.Id).Result;
            result.Show = model.Show;
            _comment.UpdateCommentFood(result);
        }

        public void DeleteComment(string id)
        {
            var result = _comment.GetCommentFoodById(id).Result;
            _comment.DeleteCommentFood(result);
        }
    }
}
