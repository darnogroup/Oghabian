using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class AdsEntity
    {
        public string AdsId { set; get; } = Guid.NewGuid().ToString();
        public string ImageOne { set; get; }
        public string ImageOneAlt { set; get; }
        public string ImageOneLink { set; get; }
        public string ImageTwo { set; get; }
        public string ImageTwoAlt { set; get; }
        public string ImageTwoLink { set; get; }
        public string ImageSidebar { set; get; }
        public string ImageSidebarAlt { set; get; }
        public string ImageSidebarLink { set; get; }
        /***********************/
        public string ImageHomeOne { set; get; }
        public string ImageHomeOneAlt { set; get; }
        public string ImageHomeOneLink { set; get; }


        public string ImageHomeTwo { set; get; }
        public string ImageHomeTwoAlt { set; get; }
        public string ImageHomeTwoLink { set; get; }


        public string ImageHomeThree { set; get; }
        public string ImageHomeThreeAlt { set; get; }
        public string ImageHomeThreeLink { set; get; }
    }
}
