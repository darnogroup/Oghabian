using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;

namespace Application.ViewModel.RegisterOrder
{
    public class RegisterViewModel
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Number { set; get; }
        public string Time { set; get; }
        public string Price { set; get; }
        public bool Pay { set; get; }
        public ConditionEnumViewModel Condition { set; get; }
    }
}
