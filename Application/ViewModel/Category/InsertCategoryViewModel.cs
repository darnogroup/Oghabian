using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Category
{
   public  class InsertCategoryViewModel
    {
        [Required(ErrorMessage = "نام دسته بندی را وارد کنید")]
        public string CategoryTitle { set; get; }
    }
}
