using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Question
{
   public class UpdateQuestionViewModel
    {
        [Required(ErrorMessage = "عنوان سوال الزامی است")]
        public string QuestionTitle { set; get; }
        [Required(ErrorMessage = "پاسخ سوال الزامی است")]

        public string QuestionAnswer { set; get; }
        public string QuestionId { set; get; }
    }
}
