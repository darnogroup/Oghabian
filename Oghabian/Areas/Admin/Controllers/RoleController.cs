using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModel.Role;
using Microsoft.AspNetCore.Identity;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _role;

        public RoleController(RoleManager<IdentityRole> role)
        {
            _role = role;

        }

        [HttpGet]
        [Route("/Admin/Roles")]
        public IActionResult Index()
        {
            var pageModel = _role.Roles.Select(s => new RoleViewModel()
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Role/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/Role/Create")]
        public IActionResult Create(InsertRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = model.Name;
                var result = _role.CreateAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Alert = "خطای غیر منتظره رخ داده با پشتیبان تماس بگیرید";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Role/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var role = _role.FindByIdAsync(id).Result;
            UpdateRoleViewModel model = new UpdateRoleViewModel()
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Role/Edit/{id}")]
        public IActionResult Edit(UpdateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = _role.FindByIdAsync(model.Id).Result;
                role.Name = model.Name;
                var result = _role.UpdateAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Alert = "خطای غیر منتظره رخ داده با پشتیبان تماس بگیرید";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/role/Delete/{id}")]
        public bool Delete(string id)
        {
            var role = _role.FindByIdAsync(id).Result;
            var result = _role.DeleteAsync(role).Result;
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
