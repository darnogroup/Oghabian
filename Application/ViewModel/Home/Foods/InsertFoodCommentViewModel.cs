using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home.Foods
{
    public class InsertFoodCommentViewModel
    {
        public string CommentBody { set; get; }
        public string FoodId { set; get; }
        public string UserId { set; get; }
    }
}
