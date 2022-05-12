using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Sickness
{
    public class InsertSicknessViewModel
    {
        [Required(ErrorMessage = "نام بیماری را وارد کنید")]
        public string SicknessTitle { set; get; }
        [Required(ErrorMessage = "تصویر بیماری را آپلود کنید")]

        public IFormFile SicknessFile { set; get; }
    
    }
}
