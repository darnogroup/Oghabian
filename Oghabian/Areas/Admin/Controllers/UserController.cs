using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")][Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _user;
        private readonly RoleManager<IdentityRole> _role;

        public UserController(IUserService user, RoleManager<IdentityRole> role)
        {
            _user = user;
            _role = role;
        }
        [HttpGet][Route("/Admin/Users")]
        public IActionResult Index(int page=1,string search="")
        {

            ViewBag.Search = search;
            var pageModel = _user.GetUsers(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/User/Create")]
        public IActionResult Create()
        {
          Role();
            return View();
        }
        [HttpPost]
        [Route("/Admin/User/Create")]
        public IActionResult Create(InsertUserViewModel model)
        {
            if (ModelState.IsValid)
            {

                var check = _user.InsertUser(model);
                if (check)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Role(model.Role);
                    ViewBag.Alert = "خطای غیر منتظره رخ داده با پشتیبان تماس بگیرید";
              
                    return View(model);
                }
            }
            else
            {
                Role(model.Role);
            
                return View(model);
            }
        }



        [HttpGet]
        [Route("/Admin/User/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var pageModel = _user.GetUserById(id).Result;
            Role(pageModel.Role);
          
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/User/Edit/{id}")]
        public IActionResult Edit(UpdateUserViewModel model)
        {
            if (ModelState.IsValid)
            {

                var check = _user.UpdateUser(model);
                if (check)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Alert = "خط ای غیر منتظره رخ داده با پشتیبان تماس بگیرید";
                    Role(model.Role);
               
                    return View(model);
                }
            }
            else
            {
                ViewBag.Alert = null;
                Role(model.Role);
             
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/User/Medical/{id}")]
        public IActionResult Medical(string id)
        {
            var pageModel = _user.GetMedicalInformationViewModel(id).Result;
            Sickness(pageModel.SicknessId);
            return View(pageModel);
        } 
        [HttpPost]
        [Route("/Admin/User/Medical/{id}")]
        public IActionResult Medical(MedicalInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                _user.ChangeMedicalInformation(model);
                return RedirectToAction(nameof(Index), new {id = model.UserId});
            }
            else
            {
                Sickness(model.SicknessId);
           
              return View();
            }
        }
        [HttpGet]
        [Route("/Admin/User/Delete/{id}")]
        public bool Delete(string id)
        {
            return _user.DeleteUser(id);
        }
        public void Sickness(string selectId = "")
        {
            var result = _user.GetSickness().Result;
            ViewBag.Sickness = new SelectList(result, "Value", "Text", selectId);

        }
        public void Role(string select = "")
        {
            var roles = _role.Roles.ToList();

            ViewBag.Roles = new SelectList(roles, "Name", "Name", select);

        }
    }
}
