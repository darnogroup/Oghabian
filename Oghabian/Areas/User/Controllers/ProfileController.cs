using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Home.Profile;
using Application.ViewModel.User;
using Domin.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Oghabian.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IProfileService _profile;
        private readonly IUserService _user;
        private readonly IHomeService _home;

        public ProfileController(UserManager<UserEntity> userManager, IProfileService profile, IUserService user, IHomeService home)
        {
            _userManager = userManager;
            _profile = profile;
            _user = user;
            _home = home;
        }

        [HttpGet]
        [Route("/Profile")]
        public IActionResult Profile()
        {
            var user = _userManager.FindByIdAsync(UserId()).Result;
            ProfileViewModel profile = new ProfileViewModel();
            profile.Mail = user.Email;
            profile.Name = user.UserFullName;
            profile.Avatar = user.UserAvatar;
            profile.Id = UserId();
            return View(profile);
        }

        public string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        [Route("Profile/Edit")]
        public IActionResult Edit(string message = null)
        {
            ViewBag.Alert = message;
            var user = _userManager.FindByIdAsync(UserId()).Result;
            EditProfileViewModel profile = new EditProfileViewModel();
            profile.ImagePath = user.UserAvatar;
            return View(profile);
        }

        [HttpPost]
        [Route("/Profile/Edit")]
        public IActionResult Edit(EditProfileViewModel profile)
        {
            var user = _userManager.FindByIdAsync(UserId()).Result;
            if (profile.Image != null)
            {
                var check = profile.Image.IsImage();
                if (check)
                {
                    var path = ImageProcessing.SaveImage(profile.Image);
                    user.UserAvatar = path;
                    if (profile.ImagePath != "male.jpg")
                    {
                        ImageProcessing.RemoveImage(profile.ImagePath);
                    }

                    Claim? avatar = User.Claims.FirstOrDefault(w => w.Type == "Avatar");
                    if (avatar != null)
                    {
                        _userManager.RemoveClaimAsync(user, avatar);
                    }

                    Claim userImage = new Claim("Avatar", path, ClaimValueTypes.String);
                    _userManager.AddClaimAsync(user, userImage);
                    _userManager.UpdateAsync(user);
                }
            }

            if (!string.IsNullOrEmpty(profile.OldPassword) && !string.IsNullOrEmpty(profile.Password))
            {
                var old = PasswordProcessing.Base64Decode(user.LoginKey);
                if (old != profile.OldPassword)
                {
                    return RedirectToAction(nameof(Edit), new {message = "گذر واژه فعلی نامعتبر است"});
                }
                else
                {

                    user.LoginKey = PasswordProcessing.Base64Encode(profile.Password);
                    _userManager.RemovePasswordAsync(user);
                    _userManager.AddPasswordAsync(user, profile.Password); _userManager.UpdateAsync(user);
                    return Redirect("/signout");
                }
            }
            else if (!string.IsNullOrEmpty(profile.OldPassword) && string.IsNullOrEmpty(profile.Password))
            {
                return RedirectToAction(nameof(Edit), new { message = "گذر واژه جدید را وارد کنید" });
            }
            else
            {
                return RedirectToAction(nameof(Profile));
            }
        }

        [HttpGet]
        [Route("/Profile/Address")]
        public IActionResult Address(string message=null)
        {
            ViewBag.Alert = message;
            var pageModel = _profile.GetAddress(UserId()).Result;
            pageModel.UserId = UserId();
            City(pageModel.StateId,pageModel.CityId);
            State(pageModel.StateId);
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Profile/Address")]
        public IActionResult Address(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                _profile.UpdateAddress(model);
                return RedirectToAction(nameof(Profile));
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        [Route("/GetCity/{id}")]
        public JsonResult GetCity(string id)
        {
            var list = _profile.GetCity(id).Result;
            var result = new SelectList(list, "Value", "Text");
            return Json(result);
        }
       
        public void City(string id, string selectId = "0")
        {
            var city = _profile.GetCity(id).Result;

            ViewBag.Cities = new SelectList(city, "Value", "Text", selectId);
        }
        public void State( string selectId = "0")
        {
            var states = _profile.GetState().Result;

            ViewBag.States = new SelectList(states, "Value", "Text", selectId);
        }

        [HttpGet]
        [Route("/Profile/Favorite")]
        public IActionResult Favorite()
        {
            var pageModel = _profile.GetUserFavorite(UserId()).Result;
            return View(pageModel);
        }
        public void Sickness(string selectId = "")
        {
            var result = _user.GetSickness().Result;
            ViewBag.Sickness = new SelectList(result, "Value", "Text", selectId);

        }
        [HttpGet]
        [Route("/Profile/Medical")]
        public IActionResult Medical()
        {
            var pageModel = _user.GetMedicalInformationViewModel(UserId()).Result;
            pageModel.UserId = UserId();
            Sickness(pageModel.SicknessId);
            return View(pageModel);
        }
        [HttpPost]
        [Route("/Profile/Medical")]
        public IActionResult Medical(MedicalInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
             _user.ChangeMedicalInformation(model);
                return RedirectToAction(nameof(Profile), new { id = model.UserId });
            }
            else
            {
                Sickness(model.SicknessId);

                return View();
            }
        }

        [HttpGet]
        [Route("/RemoveFavorite/{id}")]
        public void RemoveFavorite(string id)
        {
            _profile.DeleteFavorite(id);
        }
        [HttpGet]
        [Route("/AddFavorite/{id}")]
        public void AddFavorite(string id)
        {
            AddFavoriteViewModel model=new AddFavoriteViewModel();
            model.FoodId = id;
            model.UserId = UserId();
            _profile.AddFavorite(model);
        }

        [HttpGet]
        [Route("/Profile/Cart")]
        public IActionResult Cart()
        {
            var pageModel = _home.GetCart(UserId());
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Profile/AcceptOrder")]
        public IActionResult AcceptOrder()
        {
            var exist = _home.ExistAddress(UserId()).Result;
            if (exist == false)
            {
                return Redirect("/Profile/Address");
            }
            else
            {
                var pageModel = _home.GetCardAddress(UserId()).Result;
                return View(pageModel);
            }
          
        }
        [HttpGet]
        [Route("/RemoveOrderDetail/{id}")]
        public void RemoveOrderDetail(string id)
        {
            _home.RemoveOrderDetail(id);
         
        }

        [HttpGet]
        [Route("/RunDiscount/{code}")]
        public int RunDiscount(string code)
        {
            var x = _profile.RunDiscount(code, UserId()).Result;
            if (x)
            {
                return 1;
            }
            else
            {
                return 2;
            }
            // return _profile.RunDiscount(code, UserId()).Result;
        }

        [HttpGet][Route("/profile/finishOrder")]
        public IActionResult FinishOrder()
        {
             ViewBag.pageModel = _profile.FinishOrder(UserId()).Result;
            return View();
        }
    }
}
