using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class ChatMessageEntity
    {
        public string Id { set; get; } = Guid.NewGuid().ToString();
        public string Text { set; get; }
        public string Sender { set; get; }
        public DateTime Time { set; get; }
        public string ChatId { set; get; }
        public ChatEntity Chat { set; get; }
    }
}
