using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home.ImmediateOrder
{
   public  class SelectPersonViewModel
    {
        [Required(ErrorMessage = "انتخاب یک گزینه الزامی است")]
        public int Person { set; get; }
    }
}
