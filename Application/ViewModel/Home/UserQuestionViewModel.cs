using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home
{
    public class UserQuestionViewModel
    {
        public string Id { set; get; }
        public string Title { set; get; }
        public string UserFullName { set; get; }
        public string Time { set; get; }
        public string Body { set; get; }
    }
}
