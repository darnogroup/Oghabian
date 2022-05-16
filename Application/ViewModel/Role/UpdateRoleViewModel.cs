using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Role
{
   public  class UpdateRoleViewModel
    {
        [Required(ErrorMessage = "نام نقش الزامی است")]
        public string Name { set; get; }
        public string Id { set; get; }
    }
}
