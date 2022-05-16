using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Microsoft.AspNetCore.Http;


namespace Application.ViewModel.User
{
    public class InsertUserViewModel
    {
        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
        public string UserFullName { set; get; }
        [Required(ErrorMessage = "پست الکترونیک الزامی است")]
        public string UserMail { set; get; }
        [Required(ErrorMessage = "شماره تلفن الزامی است")]
        public string UserNumber { set; get; }
        public bool ActiveNumber { set; get; }
        public bool ActiveMail { set; get; }
        [Required(ErrorMessage = "انتخاب  نقش الزامی است")]
        public string Role { set; get; }
        [Required(ErrorMessage = "گذر واژه الزامی است")]
        [DataType(DataType.Password,ErrorMessage = "گذر واژه غیر مجاز است")]
        public string UserPassword { set; get; }
        public bool MedicalRecords { set; get; }
        public IFormFile UserAvatar { set; get; }
    }
}
