using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Selection;
using Application.ViewModel.User;

namespace Application.Service.Interface
{
    public interface IUserService
    {
        Tuple<List<UserViewModel>, int, int> GetUsers(int page, string search = "");
        Task<UpdateUserViewModel> GetUserById(string id);
        bool InsertUser(InsertUserViewModel model);
        bool UpdateUser(UpdateUserViewModel model);
        bool DeleteUser(string id);
        Task<List<SelectViewModel>> GetSickness();
        Task<MedicalInformationViewModel> GetMedicalInformationViewModel(string id);
        void ChangeMedicalInformation(MedicalInformationViewModel model);
    }
}
