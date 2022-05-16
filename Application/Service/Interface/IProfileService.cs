﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Home.Profile;
using Application.ViewModel.Selection;
using Application.ViewModel.User;

namespace Application.Service.Interface
{
   public interface IProfileService
   {
       Task<List<SelectViewModel>> GetState();
       Task<List<SelectViewModel>> GetCity(string id);
       Task<AddressViewModel> GetAddress(string id);
       void UpdateAddress(AddressViewModel model);
       Task<List<FavoriteViewModel>> GetUserFavorite(string id);
       void AddFavorite(AddFavoriteViewModel model);
       void DeleteFavorite(string favoriteId);
      
    }
}