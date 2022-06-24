using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Mail
{
    public class SendMailViewModel
    {
        [Required(ErrorMessage = "عنوان پیام خالی است")]
        public  string Title { set; get; }
        [Required(ErrorMessage = "متن پیام خالی است")]
        public string Text { set; get; }
    }
}
