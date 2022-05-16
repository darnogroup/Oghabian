using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home.Identity
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        public string FullName { set; get; }
        [Required(ErrorMessage = "پست الکترونیک را وارد کنید")]
        public string Mail { set; get; }
        [Required(ErrorMessage = "شماره تماس را وارد کنید")]
        public string PhoneNumber { set; get; }
        [Required(ErrorMessage = "گذر واژه را وارد کنید")]
        public string Password { set; get; }
        [Compare("Password",ErrorMessage = "گذر واژه و تکرار گذر واژه یکسان نمی باشد")]
        public string ComparePassword { set; get; }
      
        public bool Accept { set; get; } 
    }
}
