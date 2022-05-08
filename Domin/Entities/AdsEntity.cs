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
    }
}
