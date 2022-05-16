using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home.Identity
{
    public class RestPasswordViewModel
    {
        public string Id { set; get; }
        public string Token { set; get; }
        [Required(ErrorMessage = "گذر واژه را وارد کنید")]
        public string Password { set; get; }
        [Compare("Password", ErrorMessage = "گذر واژه و تکرار گذر واژه یکسان نمی باشد")]
        public string ComparePassword { set; get; }
    }
}
