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

        public string ImageHomeOne { set; get; }
        public IFormFile ImageHomeOneFile { set; get; }
        public string ImageHomeOneAlt { set; get; }
        public string ImageHomeOneLink { set; get; }


        public string ImageHomeTwo { set; get; }
        public IFormFile ImageHomeTwoFile { set; get; }
        public string ImageHomeTwoAlt { set; get; }
        public string ImageHomeTwoLink { set; get; }


        public string ImageHomeThree { set; get; }
        public IFormFile ImageHomeThreeFile { set; get; }
        public string ImageHomeThreeAlt { set; get; }
        public string ImageHomeThreeLink { set; get; }
    }
}
