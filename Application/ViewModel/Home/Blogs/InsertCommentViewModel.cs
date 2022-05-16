using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home.Blogs
{
    public class InsertCommentViewModel
    {
        public string CommentBody { set; get; }
        public string ArticleId { set; get; }
        public string UserId { set; get; }
    }
}
