using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Supporter
{
    public class UpdateSupporterViewModel
    {
        public string SupporterId { set; get; }
        [Required(ErrorMessage = "نام شریک تجاری الزامی است")]
        public string SupporterName { set; get; }
        [Required(ErrorMessage = "مدت فعالیت شریک تجاری الزامی است")]
        public string SupporterActivity { set; get; }
        [Required(ErrorMessage = "پست الکترونیک شریک تجاری الزامی است")]
        public string SupporterMail { set; get; }
        [Required(ErrorMessage = "شماره تماس شریک تجاری الزامی است")]
        public string SupporterNumber { set; get; }
        [Required(ErrorMessage = "نشانی شریک تجاری الزامی است")]
        public string SupporterAddress { set; get; }
        public string SupporterImagePath { set; get; }
        public IFormFile SupporterImage { set; get; }
        [Required(ErrorMessage = "توضیحات درباره شریک تجاری الزامی است")]
        public string SupporterDescription { set; get; }
    }
}
