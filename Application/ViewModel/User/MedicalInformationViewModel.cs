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
    public class MedicalInformationViewModel
    {
        public string MedicalId { set; get; }
        public string UserId { set; get; }
        [Required(ErrorMessage = "قد الزامی است")]
        public string UserHeight { set; get; }
        [Required(ErrorMessage = "وزن الزامی است")]
        public string UserWeight { set; get; }
        [Required(ErrorMessage = "سن الزامی است")]
        public string UserAge { set; get; }
        [Required(ErrorMessage = "انتخاب  بیماری الزامی است")]
        public string SicknessId { set; get; }
        public IFormFile UserFile { set; get; }
        public string UserFileDownload { set; get; }
        [Required(ErrorMessage = "انتخاب  جنسیت الزامی است")]
        public GenderEnumViewModel? Gender { set; get; }
        public string UserCalories { set; get; }
        public string UserCarbohydrate { set; get; }
        public string UserFat { set; get; }
        public string UserProtein { set; get; }
    }
}
