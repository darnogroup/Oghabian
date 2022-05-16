using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Home.Profile;
using Application.ViewModel.Selection;
using Application.ViewModel.User;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class ProfileService:IProfileService
    {
        private readonly IProfileInterface _profile;
        private readonly IUserInterface _user;

        public ProfileService(IProfileInterface profile, IUserInterface user)
        {
            _profile = profile;
            _user = user;
        }
        public async Task<List<SelectViewModel>> GetState()
        {
            var states = await _profile.GetState();
            List<SelectViewModel> models=new List<SelectViewModel>();
            foreach (var item in states)
            {
                models.Add(new SelectViewModel()
                {
                    Text=item.StateName,
                    Value = item.StateId
                });
            }

            return models;
        }

        public async Task<List<SelectViewModel>> GetCity(string id)
        {
            var cities = await _profile.GetCities(id);
            List<SelectViewModel> models = new List<SelectViewModel>();
            foreach (var item in cities)
            {
                models.Add(new SelectViewModel()
                {
                    Text = item.CityName,
                    Value = item.CityId
                });
            }

            return models;
        }

        public async Task<AddressViewModel> GetAddress(string id)
        {
            var address =await _profile.GetAddress(id);
            AddressViewModel model=new AddressViewModel();
            if (address != null)
            {
                model.StateId = address.StateId;
                model.AddressCode = address.AddressCode;
                model.AddressText = address.AddressText;
                model.CityId = address.CityId;
            }
            else
            {
                model.StateId = "";
                model.AddressCode = "";
                model.AddressText = "";
                model.CityId = "";
            }

            return model;
        }

        public void UpdateAddress(AddressViewModel address)
        {
            var model = _profile.GetAddress(address.UserId).Result;
            if (model == null)
            {
                AddressEntity entity=new AddressEntity();
                entity.StateId = address.StateId;
                entity.AddressCode = address.AddressCode;
                entity.AddressText = address.AddressText;
                entity.CityId = address.CityId;
                entity.UserId = address.UserId;
                _profile.InsertAddress(entity);
            }
            else
            {
                model.StateId = address.StateId;
                model.AddressCode = address.AddressCode;
                model.AddressText = address.AddressText;
                model.CityId = address.CityId;
                _profile.UpdateAddress(model);
            }
        }

        public async Task<List<FavoriteViewModel>> GetUserFavorite(string id)
        {
            var result = await _profile.GetFavorites(id);
            List<FavoriteViewModel>favorite=new List<FavoriteViewModel>();
            foreach (var item in result)
            {
                favorite.Add(new FavoriteViewModel()
                {
                    FoodCalories = item.Food.FoodCalories,
                    FoodCarbohydrate = item.Food.FoodCarbohydrate,
                    FoodFat = item.Food.FoodFat,
                    FoodProtein = item.Food.FoodProtein,
                    FavoriteId = item.FavoriteId,
                    FoodId = item.FoodId,
                    Image = item.Food.FoodImage,
                    Title = item.Food.FoodTitle
                });
            }

            return favorite;
        }

        public void AddFavorite(AddFavoriteViewModel model)
        {
            var check = _profile.Exist(model.UserId, model.FoodId);
            if(check==false)
            {
                FavoriteEntity favorite = new FavoriteEntity();
                favorite.FoodId = model.FoodId;
                favorite.UserId = model.UserId;
                _profile.AddFavorite(favorite);
            }
          
        }

        public void DeleteFavorite(string favoriteId)
        {
            var model = _profile.GetFavoriteById(favoriteId).Result;
            _profile.DeleteFavorite(model);
        }
      
    }
}
