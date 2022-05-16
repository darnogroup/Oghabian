using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
   public interface IUserInterface
    {
        Task<IEnumerable<UserEntity>> GetUsers(string search, int skip);
        int CountUser(); 
        Task<UserEntity> GetUserByNumber(string number, string code);
        Task<UserEntity> FindUserByNumber(string number);
        void UpdateUser(UserEntity user);

        Task<MedicalInformationEntity> GetMedicalInformation(string id);
        void Update(MedicalInformationEntity model);
        void Insert(MedicalInformationEntity model);
    }
}
