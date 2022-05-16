using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home.Blogs
{
    public class BlogViewModel
    {
        public string BlogId { set; get; }
        public string Time { set; get; }
        public string CreateTime { set; get; }
        public string Title { set; get; }
        public string ImagePath { set; get; }
        public int Visit { set; get; }
        public string Category { set; get; }
        public string Summary { set; get; }
    }
}
