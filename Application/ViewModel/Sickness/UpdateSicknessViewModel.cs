using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Sickness
{
    public class UpdateSicknessViewModel
    {
        [Required(ErrorMessage = "نام بیماری را وارد کنید")]
        public string SicknessTitle { set; get; }
      public string SicknessPath { set; get; }
        public string SicknessId { set; get; }
        public IFormFile SicknessFile { set; get; }
    }
}
