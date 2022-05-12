using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.City;

namespace Application.Service.Interface
{
    public interface ICityService
    {
        Tuple<List<CityViewModel>, int, int> GetCities(string state,int page, string search = "");

        Task<UpdateCityViewModel> GetCityById(string id);
        bool InsertCity(InsertCityViewModel model);
        bool UpdateCity(UpdateCityViewModel model);

        bool DeleteCity(string id);
    }
}
