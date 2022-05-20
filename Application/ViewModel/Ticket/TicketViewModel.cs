using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Enum;

namespace Application.ViewModel.Ticket
{
   public  class TicketViewModel
    {
        public string TicketId { set; get; }
        public string TicketTitle { set; get; }
        public string UserName { set; get; }
        public string Avatar { set; get; }
        public string TicketTime { set; get; }
        public MessageStatus Status { set; get; }
    }
}
