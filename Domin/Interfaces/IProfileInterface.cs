using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IProfileInterface
    {
        Task<bool> ExistAddress(string user);
        Task<List<StateEntity>> GetState();
        Task<List<CityEntity>> GetCities(string state);
        Task<AddressEntity> GetAddress(string user);
        void InsertAddress(AddressEntity address);
        void UpdateAddress(AddressEntity address);
        Task<List<FavoriteEntity>> GetFavorites(string id);
        void AddFavorite(FavoriteEntity favorite);
        void DeleteFavorite(FavoriteEntity favorite);
        Task<FavoriteEntity> GetFavoriteById(string id);
        Task<MedicalInformationEntity> GetMedicalInformation(string id);
        void Update(MedicalInformationEntity model);
        void Insert(MedicalInformationEntity model);
        bool Exist(string user, string food);
        Task<string> SenPrice();
        Task<string> FullName(string id);
        Task<bool> ExistDiscount(string code);
        Task<DiscountEntity> GetWithCode(string code);
    }
}
