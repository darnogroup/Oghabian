using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.City
{
    public class InsertCityViewModel
    {
        [Required(ErrorMessage = "نام شهر را وارد کنید")]
        public string CityName { set; get; }
        public string StateId { set; get; }
    }
}
