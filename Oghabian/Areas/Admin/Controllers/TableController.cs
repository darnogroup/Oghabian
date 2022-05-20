using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Table;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TableController : Controller
    {
        private readonly ITableService _table;

        public TableController(ITableService table)
        {
            _table = table;
        }
        [HttpGet][Route("/Admin/Tables")]
        public IActionResult Index(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _table.GetTables(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Table/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("/Admin/Table/Create")]
        public IActionResult Create(InsertTableViewModel model)
        {
            if (ModelState.IsValid)
            {
                _table.InsertRow(model);
                return LocalRedirect("/Admin/Tables");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Table/Edit")]
        public IActionResult Edit(string id)
        {
            var pageModel = _table.UpdateRowViewModel(id).Result;
            return View(pageModel);
        }
        [HttpPost]
        [Route("/Admin/Table/Edit")]
        public IActionResult Edit(UpdateTableViewModel model)
        {
            if (ModelState.IsValid)
            {
                _table.UpdateRow(model);
                return LocalRedirect("/Admin/Tables");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Table/Column")]
        public IActionResult Column(string id)
        {
            ViewBag.Id = id;
            var pageModel = _table.GetColumns(id).Result;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Table/CreateColumn")]
        public IActionResult CreateColumn(string id)
        {
            var result = _table.UpdateRowViewModel(id).Result;
            InsertColumnViewModel column=new InsertColumnViewModel();
            column.RowId = id;
            column.Rows =result.Rows;
            column.Count = result.Rows.Count();
            return View(column);
        }

        [HttpPost]
        [Route("/Admin/Table/CreateColumn")]
        public IActionResult CreateColumn(InsertColumnViewModel model)
        {
            if (ModelState.IsValid && model.Columns.Count()==model.Count)
            {
                _table.InsertColumn(model);
                return RedirectToAction(nameof(Index), new {id = model.RowId});
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Table/DeleteRow/{id}")]
        public void DeleteRow(string id)
        {
            _table.DeleteRow(id);
        } [HttpGet]
        [Route("/Admin/Table/DeleteColumn/{id}")]
        public void DeleteColumn(string id)
        {
            _table.DeleteColumn(id);
        }
    }
}
