using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Selection;
using Application.ViewModel.User;
using Domin.Entities;
using Domin.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Service.Repository
{
    public class UserService : IUserService
    {
        private readonly IUserInterface _user;

        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IGeneralInterface _general;

        public UserService(IUserInterface user, UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager, IGeneralInterface general)
        {
            _user = user;
            _userManager = userManager;
            _roleManager = roleManager;
            _general = general;
        }

        public Tuple<List<UserViewModel>, int, int> GetUsers(int page, string search = "")
        {
            int pageSelected = page;
            int count = _user.CountUser().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _user.GetUsers(search, pageSkip).Result;
            List<UserViewModel> users = new List<UserViewModel>();

            foreach (var item in list)
            {
                users.Add(new UserViewModel()
                {
                    UserId = item.Id,
                    UserAvatar = item.UserAvatar,
                    UserFullName = item.UserFullName,
                    UserMail = item.Email,MedicalRecords = item.MedicalRecords
                });
            }
            return Tuple.Create(users, count, pageSelected);
        }

        public async Task<UpdateUserViewModel> GetUserById(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            UpdateUserViewModel user = new UpdateUserViewModel();
            user.UserId = result.Id;
            user.UserMail = result.Email;
            user.ActiveMail = result.EmailConfirmed;
            user.ActiveNumber = result.PhoneNumberConfirmed;
            user.AvatarPath = result.UserAvatar;
            user.UserCurrentPassword = PasswordProcessing.Base64Decode(result.LoginKey);
            user.UserPassword = PasswordProcessing.Base64Decode(result.LoginKey);
            user.UserFullName = result.UserFullName;
            user.UserNumber = result.PhoneNumber;
            var role = _roleManager.FindByNameAsync(result.Role).Result;
            user.Role = role.Name;
            user.CurrentRole = role.Id;
            user.MedicalRecords = result.MedicalRecords;
            return user;
        }

        public bool InsertUser(InsertUserViewModel model)
        {
            Random random = new Random();
            UserEntity user = new UserEntity();
            user.UserName = model.UserMail;
            user.MedicalRecords = model.MedicalRecords;
            user.Email = model.UserMail;
            user.EmailConfirmed = model.ActiveMail;
            user.PhoneNumberConfirmed = model.ActiveNumber;
            user.LoginKey = PasswordProcessing.Base64Encode(model.UserPassword);
            user.UserFullName = model.UserFullName;
            user.PhoneNumber = model.UserNumber;
            var role = _roleManager.FindByNameAsync(model.Role).Result;
            user.Role = model.Role; user.LoginCode = random.Next(999, 9999).ToString();
            user.Time = DateTime.Now;
            if (model.UserAvatar != null)
            {
                var check = model.UserAvatar.IsImage();
                if (check)
                {
                    user.UserAvatar = ImageProcessing.SaveImage(model.UserAvatar);
                }
                else
                {
                  
                        user.UserAvatar = "male.jpg";
                  

                }
            }
            else
            {
            
                    user.UserAvatar = "male.jpg";
              
            }
            try
            {
                var result = _userManager.CreateAsync(user, model.UserPassword).Result;
                if (result.Succeeded)
                {
                    var roleResult = _userManager.AddToRoleAsync(user, model.Role).Result;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateUser(UpdateUserViewModel model)
        {
            var user = _userManager.FindByIdAsync(model.UserId).Result;
            user.Email = model.UserMail;
            user.EmailConfirmed = model.ActiveMail;
            user.PhoneNumberConfirmed = model.ActiveNumber;
            if (!string.IsNullOrEmpty(model.UserPassword))
            {
                user.LoginKey = PasswordProcessing.Base64Encode(model.UserPassword);
            }

            user.MedicalRecords = model.MedicalRecords;
            user.UserFullName = model.UserFullName;
            user.PhoneNumber = model.UserNumber;
            var role = _roleManager.FindByNameAsync(model.Role).Result;
            if (role.Id != model.CurrentRole)
            {
                var oldRole = _roleManager.FindByIdAsync(model.CurrentRole).Result;
                var delete = _userManager.RemoveFromRoleAsync(user, oldRole.Name).Result;
                var add = _userManager.AddToRoleAsync(user, role.Name).Result;
                user.Role = role.Name;
            }
            if (model.UserAvatar != null)
            {
                var check = model.UserAvatar.IsImage();
                if (check)
                {
                    user.UserAvatar = ImageProcessing.SaveImage(model.UserAvatar);
                    if (model.AvatarPath != "female.jpg" && model.AvatarPath != "male.jpg")
                    {
                        ImageProcessing.RemoveImage(model.AvatarPath);
                    }
                }

            }



            try
            {
                var result = _userManager.UpdateAsync(user).Result;

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.UserPassword))
                    {
                        user.LoginKey = PasswordProcessing.Base64Encode(model.UserPassword);
                        _userManager.RemovePasswordAsync(user);
                        _userManager.AddPasswordAsync(user, model.UserPassword);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;

            try
            {
                var result = _userManager.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
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

        public async Task<MedicalInformationViewModel> GetMedicalInformationViewModel(string id)
        {
            var medical = await _user.GetMedicalInformation(id);
            MedicalInformationViewModel model = new MedicalInformationViewModel();
            if (medical != null)
            {
                model.Gender = ConvertEnum.ChangeGenderToViewModel(medical.UserGender);
                model.SicknessId = medical.SicknessId;
                model.UserAge = medical.UserAge;
                model.UserWeight = medical.UserWeight;
                model.UserHeight = medical.UserHeight;
                model.UserId = medical.UserId;
                model.UserFileDownload = medical.MedicalRecords;
                model.MedicalId = medical.Id;
                model.UserCarbohydrate = medical.UserCarbohydrate;
                model.UserCalories = medical.UserCalories;
                model.UserFat = medical.UserFat;
                model.UserProtein = medical.UserProtein;
            }
            else
            {
                model.UserCarbohydrate = "";
                model.UserCalories = "";
                model.UserFat = "";
                model.UserProtein = "";
                model.Gender = null;
                model.SicknessId = "";
                model.UserAge = "";
                model.UserWeight = "";
                model.UserHeight = "";
                model.UserId = id;
                model.UserFileDownload = null;
            }
            return model;
        }

        public void ChangeMedicalInformation(MedicalInformationViewModel model)
        {
            var medical = _user.GetMedicalInformation(model.UserId).Result;
            if (medical == null)
            {
                MedicalInformationEntity entity = new MedicalInformationEntity();
                entity.SicknessId = model.SicknessId;
                entity.UserAge = model.UserAge;
                entity.UserCarbohydrate = model.UserCarbohydrate;
                entity.UserCalories = model.UserCalories;
                entity.UserFat = model.UserFat;
                entity.UserProtein = model.UserProtein;
                if (model.Gender != null) entity.UserGender = ConvertEnum.ChangeGenderToModel(model.Gender.Value);
                entity.UserHeight = model.UserHeight;
                entity.UserId = model.UserId;
                entity.UserWeight = model.UserWeight;
                if (model.UserFile != null)
                {
                 entity.MedicalRecords=   FileProcessing.SaveFile(model.UserFile);
                }
                _user.Insert(entity);
            }
            else
            {
                medical.UserCarbohydrate = model.UserCarbohydrate;
                medical.UserCalories = model.UserCalories;
                medical.UserFat = model.UserFat;
                medical.UserProtein = model.UserProtein;
                medical.SicknessId = model.SicknessId;
                medical.UserAge = model.UserAge;
                if (model.Gender != null) medical.UserGender = ConvertEnum.ChangeGenderToModel(model.Gender.Value);
                medical.UserHeight = model.UserHeight;
                medical.UserId = model.UserId;
                medical.UserWeight = model.UserWeight;
                if (model.UserFile != null)
                {
                    medical.MedicalRecords = FileProcessing.SaveFile(model.UserFile);
                    if (!string.IsNullOrEmpty(model.UserFileDownload))
                    {
                        FileProcessing.RemoveFile(model.UserFileDownload);
                    }
                }
                _user.Update(medical);
            }
        }
    }
}
