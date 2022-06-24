using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class ChatEntity
    {
        public string ChatId { set; get; } = Guid.NewGuid().ToString();
        public string ConnectionClient { set; get; }
        public DateTime Time { set; get; }
        public IEnumerable<ChatMessageEntity>Message { set; get; }
    }
}
