using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Home.Identity;
using Domin.Entities;
using Microsoft.AspNetCore.Identity;

namespace Oghabian.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ISenderService _sender;
        private readonly SignInManager<UserEntity> _signInManager;

        public AccountController(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager, ISenderService sender, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _sender = sender;
            _signInManager = signInManager;
        }
        [HttpGet][Route("/SignUp")]
        public IActionResult SignUp()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                ViewBag.Alert = null;
                return View();
            }
        } 
        [HttpPost][Route("/SignUp")]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Accept)
                {
                    Random random = new Random();
                    UserEntity user=new UserEntity();
                    user.UserName = model.Mail;
                    user.MedicalRecords = true;
                    user.Email = model.Mail;
                    user.EmailConfirmed = false;
                    user.PhoneNumberConfirmed = true;
                    user.LoginKey = PasswordProcessing.Base64Encode(model.Password);
                    user.UserFullName = model.FullName;
                    user.PhoneNumber = model.PhoneNumber;
                    var role = _roleManager.FindByNameAsync("User").Result;
                    user.Role = "User"; 
                    user.LoginCode = random.Next(999, 9999).ToString();
                    user.Time = DateTime.Now;
                    user.UserAvatar = "male.jpg";
                    var result = _userManager.CreateAsync(user, model.Password).Result;
                    if (result.Succeeded)
                    {
                        Claim claim=new Claim("Avatar",user.UserAvatar,ClaimValueTypes.String);
                        _userManager.AddClaimAsync(user,claim);
                      _userManager.AddToRoleAsync(user,"User");
                      var token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                      var link = Url.Action("ActiveAccount", "Account", new { id = user.Id, token = token },
                          protocol: Request.Scheme);
                      var text = "<a href=" + link + ">برای فعالسازی حساب کاربری در سایت بهین فود بر روی این لینک کلیک کنید</a>";
                      _sender.SendMail(user.Email, text, "فعالسازی حساب کاربری");
                        ViewBag.Alert = "ایمیلی حاوی لینک فعالسازی حساب کاربری برای شما ارسال شد";
                      return View(model);
                    }
                    else
                    {
                        var message = "";
                        foreach (var error in result.Errors.ToList())
                        {
                            message += error.Description + Environment.NewLine;
                        }

                        ViewBag.Alert = message; return View(model);
                    }
                }
                else
                {
                    ViewBag.Alert = "قوانین سایت را بپذیرید";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [Route("/SignIn")]
        public IActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = _userManager.FindByNameAsync(model.Mail).Result;
                if (user != null)
                {
                   
                    var result = _signInManager.PasswordSignInAsync(user, model.Password, model.SaveInfo, true)
                        .Result;
                    if (result.Succeeded)
                    {
                        return Redirect("/");
                    }
                    else if (result.IsLockedOut)
                    {
                        ViewBag.Alert = "حساب کاربری شما مسدود شده با مدیریت ارتباط برقرار کنید";
                        return View(model);
                    }
                    else
                    {
                        ViewBag.Alert = "نام کاربری و یا گذر واژه اشتباه است";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.Alert = "نام کاربری و یا گذر واژه اشتباه است";
                    return View(model);
                }


            }
            else
            {
                ViewBag.Alert = null;
                return View(model);
            }
        }


        [HttpGet]
        [Route("/SignIn")]
        public IActionResult SignIn()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                ViewBag.Alert = null;
                return View();
            }
        }

        [HttpGet]
        [Route("/SignOut")]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return Redirect("/");
        }
        [HttpGet]
        [Route("/Forget")]
        public IActionResult Forget()
        {
            return View();
        }

        [HttpPost]
        [Route("/Forget")]
        public IActionResult Forget(ForgetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(model.Mail).Result;
                if (user != null)
                {
                    var check = _userManager.IsEmailConfirmedAsync(user).Result;
                    if (check)
                    {
                        var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                        var link = Url.Action("RestPassword", "Account", new { id = user.Id, token = token },
                            protocol: Request.Scheme);
                        _sender.SendMail(user.Email, link, "بازیابی گذر واژه");
                        ViewBag.Alert = "لینک بازیابی برای شما ارسال شد";
                        return View();
                    }
                    else
                    {
                        ViewBag.Alert = "حساب کاربری شما تائید نشده";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Alert = "حساب کاربری یافت نشد";
                    return View();
                }

            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/RestPassword")]
        public IActionResult RestPassword(string id, string token)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(token))
            {
                return Redirect("/");
            }
            else
            {
                RestPasswordViewModel paeModel = new RestPasswordViewModel
                {
                    Id = id,
                    Token = token
                };
                return View(paeModel);
            }
        }
        [HttpPost]
        [Route("/RestPassword")]
        public IActionResult RestPassword(RestPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(model.Id).Result;
                if (user != null)
                {
                    var result = _userManager.ResetPasswordAsync(user, model.Token, model.Password).Result;
                    if (result.Succeeded)
                    {
                        user.LoginKey = PasswordProcessing.Base64Encode(model.Password);
                        _userManager.UpdateAsync(user);
                        return RedirectToAction(nameof(SignIn));
                    }
                    else
                    {
                        ViewBag.Alert = "عملیات ناموفق بود";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.Alert = "حساب کاربری یافت نشد";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        [Route("/ActiveAccount")]
        public IActionResult ActiveAccount(string id,string token)
        {
            if (id == null && token == null)
            {
                return Redirect("/404");
            }
            else
            {
                var user = _userManager.FindByIdAsync(id).Result;
                if (user != null)
                {
                    var result = _userManager.ConfirmEmailAsync(user, token).Result;
                    if (result.Succeeded)
                    {
                        ViewBag.Sucess = "حساب کاربری با موفقیت فعال شد";
                        return View();
                    }
                    else
                    {
                        ViewBag.Danger = "عملیات ناموفق بود";
                        return View();
                    }
                }
                else
                {
                    return Redirect("/");
                }
            }
        }
    }
}
