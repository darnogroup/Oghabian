using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.UserQuestion
{
    public  class UserQuestionDetailViewModel
    {
        public string Id { set; get; }
        public string Title { set; get; }
        public string Body { set; get; }
        public string Avatar { set; get; }
        public string FullName { set; get; }
        public bool Active { set; get; }
    }
}
