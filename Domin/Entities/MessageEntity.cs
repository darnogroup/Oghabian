using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class MessageEntity
    {
        public string MessageId { set; get; } = Guid.NewGuid().ToString();
        public string MessageTitle { set; get; }
        public string MessageSender { set; get; }
        public string MessageMail { set; get; }
        public string MessageNumber { set; get; }
        public string MessageBody { set; get; }

    }
}
