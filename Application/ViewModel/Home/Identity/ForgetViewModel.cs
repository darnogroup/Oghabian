using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home.Identity
{
    public class ForgetViewModel
    {
        [Required(ErrorMessage = "پست الکترونیک را وارد کنید")]
        public string Mail { set; get; }
    }
}
