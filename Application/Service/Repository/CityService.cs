using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.City;
using Application.ViewModel.Meal;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class CityService:ICityService
    {
        private readonly ICityInterface _city;

        public CityService(ICityInterface city)
        {
            _city = city;
        }
        public Tuple<List<CityViewModel>, int, int> GetCities(string state, int page, string search = "")
        {
            int pageSelected = page;
            int count = _city.CountCity(state).PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _city.GetCities(state,search, pageSkip).Result;
            List<CityViewModel> city = new List<CityViewModel>();

            foreach (var item in list)
            {
                city.Add(new CityViewModel()
                {
                    CityName = item.CityName,
                    CityId = item.CityId
                });
            }
            return Tuple.Create(city, count, pageSelected);
        }

        public async Task<UpdateCityViewModel> GetCityById(string id)
        {
            var result = await _city.GetCityById(id);
            UpdateCityViewModel city=new UpdateCityViewModel();
            city.StateId = result.StateId;
            city.CityId = result.CityId;
            city.CityName = result.CityName;
            return city;
        }

        public bool InsertCity(InsertCityViewModel model)
        {
            CityEntity city=new CityEntity();
            city.CityName = model.CityName;
            city.StateId = model.StateId;
            try
            {
                _city.InsertCity(city);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCity(UpdateCityViewModel model)
        {
            var result = _city.GetCityById(model.CityId).Result;
            result.CityName = model.CityName;
            try
            {
                _city.UpdateCity(result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCity(string id)
        {
            var result = _city.GetCityById(id).Result;
            try
            {
                _city.DeleteCity(result);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
