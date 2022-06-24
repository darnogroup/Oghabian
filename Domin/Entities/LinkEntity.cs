using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
   public class LinkEntity
   {
       public string LinkId { set; get; } = Guid.NewGuid().ToString();
        public string Link { set; get; }
        public string LinkTitle { set; get; }
    }
}
