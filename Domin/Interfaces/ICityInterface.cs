using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ICityInterface
    {
        Task<IEnumerable<CityEntity>> GetCities(string stateId,string search, int skip);
        Task<CityEntity> GetCityById(string id);
        void InsertCity(CityEntity city);
        void UpdateCity(CityEntity city);
        void DeleteCity(CityEntity city);
        int CountCity(string stateId);
    }
}
