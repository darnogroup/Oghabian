using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Ads
{
    public class AdsViewModel
    {
        public string ImageOne { set; get; }
        public IFormFile ImageOneFile { set; get; }
        public string ImageOneAlt { set; get; }
        public string ImageOneLink { set; get; }
        public string ImageTwo { set; get; }
        public IFormFile ImageTwoFile { set; get; }
        public string ImageTwoAlt { set; get; }
        public string ImageTwoLink { set; get; }
        public string ImageSidebar { set; get; }
        public IFormFile ImageSidebarFile { set; get; }
        public string ImageSidebarAlt { set; get; }
        public string ImageSidebarLink { set; get; }
    }
}
