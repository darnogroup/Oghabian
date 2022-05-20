using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class TicketDetailEntity
    {
        public string TicketDetailId { set; get; } = Guid.NewGuid().ToString();
        public string UserId { set; get; }
        public UserEntity User { set; get; }
        public string File { set; get; }
        public string Text { set; get; }
        public DateTime Time { set; get; }
        public string TicketId { set; get; }
        public TicketEntity Ticket { set; get; }
    }
}
