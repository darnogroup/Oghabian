using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home
{
    public class InsertUserQuestionViewModel
    {
        [Required(ErrorMessage = "عنوان سوال الزامی است")]
        public string Title { set; get; }
        [Required(ErrorMessage = "متن سوال الزامی است")]
        public string Body { set; get; }
        public string UserId { set; get; }
    }
}
