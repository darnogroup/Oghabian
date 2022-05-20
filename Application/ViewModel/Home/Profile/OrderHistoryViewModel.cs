using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;

namespace Application.ViewModel.Home.Profile
{
    public class OrderHistoryViewModel
    {
        public string Id { set; get; }
        public string Code { set; get; }
        public string Time { set; get; }
        public ConditionEnumViewModel Condition { set; get; }
    }
}
