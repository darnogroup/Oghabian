using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Home.Profile
{
    public class EditProfileViewModel
    {
        public string ImagePath { set; get; }
        public IFormFile Image { set; get; }
        public string OldPassword { set; get; }
        public string Password { set; get; }
        [Compare("Password", ErrorMessage = "گذر واژه و تکرار گذر واژه جدید یکسان نمی باشد")]
        public string ComparePassword { set; get; }
    }
}
