using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Setting
{
    public class ChatMessageViewModel
    {
        public string Id { set; get; }
        public string Text { set; get; }
        public string Sender { set; get; }
        public string Time { set; get; }
    }
}
