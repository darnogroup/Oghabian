using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Link
{
   public class UpdateLinkViewModel
    {
        public string LinkId { set; get; }
        [Required(ErrorMessage = "لینک را وارد کنید")]
        public string Link { set; get; }
        [Required(ErrorMessage = "عنوان لینک را وارد کنید")]
        public string LinkTitle { set; get; }
    }
}
