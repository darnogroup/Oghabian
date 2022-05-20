using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Article
{
    public class CommentArticleDetailViewModel
    {
        public string Name { set; get; }
        public string Body { set; get; }
        public string Time { set; get; }
        public string Avatar { set; get; }
        public bool Show { set; get; }
        public string Id { set; get; }
        public string ParentId { set; get; }
    }
}
