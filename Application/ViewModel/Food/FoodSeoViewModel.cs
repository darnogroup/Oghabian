using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Food
{
    public class FoodSeoViewModel
    {
        public string GraphTitle { set; get; }
        public string GraphType { set; get; }
        public string GraphUrl { set; get; }
        public IFormFile GraphImage { set; get; }
        public string GraphImagePath { set; get; }
        public string GraphDescription { set; get; }
        public string GraphSiteName { set; get; }
        public string TwitterTitle { set; get; }
        public string TwitterDescription { set; get; }
        public string TwitterImagePath { set; get; }
        public IFormFile TwitterImage { set; get; }
        public string Description { set; get; }
        public string FoodId { set; get; }
    }
}
