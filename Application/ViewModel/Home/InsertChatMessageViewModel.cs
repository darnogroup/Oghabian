using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home
{
    public class InsertChatMessageViewModel
    {
        public string GroupKey { set; get; }
        public string Message { set; get; }
        public string Sender { set; get; }
    }
}
