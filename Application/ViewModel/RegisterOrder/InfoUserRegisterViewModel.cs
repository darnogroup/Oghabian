using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;

namespace Application.ViewModel.RegisterOrder
{
    public class InfoUserRegisterViewModel
    {
        public string SicknessId { set; get; }
        public string AddressText { set; get; }
        public string AddressCode { set; get; }
        public string State{ set; get; }
        public string City{ set; get; }
        public string UserHeight { set; get; }
        public string UserWeight { set; get; }
        public GenderEnumViewModel UserGender { set; get; }
        public string UserAge { set; get; }
        public string UserCalories { set; get; }
        public string UserCarbohydrate { set; get; }
        public string UserFat { set; get; }
        public string UserProtein { set; get; }
        public string Name { set; get; }
        public string Number { set; get; }
        
    }
}
