using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home.Profile
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "انتخاب شهر الزامی است")]
        public string CityId { set; get; }
        [Required(ErrorMessage = "انتخاب استان الزامی است")]
        public string StateId { set; get; }
        [Required(ErrorMessage = "نشانی الزامی است")]
        public string AddressText { set; get; }
        [Required(ErrorMessage = "کد پستی الزامی است")]
        public string AddressCode { set; get; }
        public string UserId { set; get; }
    }
}
