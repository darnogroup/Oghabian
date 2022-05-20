using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Enum;

namespace Domin.Entities
{
    public class TicketEntity
    {
        public string TicketId { set; get; } = Guid.NewGuid().ToString();
        public string TicketTitle { set; get; }
        public MessageStatus Status { set; get; }
        public DateTime CreateTime { set; get; }
        public string UserId { set; get; }
        public UserEntity User { set; get; }
        public IEnumerable<TicketDetailEntity>Ticket { set; get; }
    }
}
