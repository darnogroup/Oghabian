using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        public string Name { set; get; }
        [Required(ErrorMessage = "پست الکترونیک را وارد کنید")]
        public string Mail { set; get; }
        [Required(ErrorMessage = "شماره موبایل را وارد کنید")]
        public string PhoneNumber { set; get; }
        [Required(ErrorMessage = "متن پیام را وارد کنید")]
        public string Body { set; get; }
    }
}
