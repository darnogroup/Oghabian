using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.UserQuestion
{
    public  class InsertAnswerViewModel
    {
        public string UserId { set; get; }
        public string QuestionId { set; get; }
        [Required(ErrorMessage = "پاسخ سوال را وارد کنید")]
        public string AnswerText { set; get; }
    }
}
