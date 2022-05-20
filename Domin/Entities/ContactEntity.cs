using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class ContactEntity
    {
        public string Id { set; get; } = Guid.NewGuid().ToString();
        public string Name { set; get; }
        public string PhoneNumber { set; get; }
        public string Mail { set; get; }
        public string Body { set; get; }
        public DateTime Time { set; get; }
    }
}
