using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home.Identity
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "پست الکترونیک را وارد کنید")]
        public string Mail { set; get; }
        [Required(ErrorMessage = "گذر واژه را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        public bool SaveInfo { set; get; }
    }
}
