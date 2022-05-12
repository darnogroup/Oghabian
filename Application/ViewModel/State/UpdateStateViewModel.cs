using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.State
{
   public class UpdateStateViewModel
    {
        [Required(ErrorMessage = "نام استان الزامی است")]
        public string StateName { set; get; }
        public string StateId { set; get; }
    }
}
