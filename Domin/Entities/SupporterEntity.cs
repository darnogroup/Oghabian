using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class SupporterEntity
    {
        public string SupporterId { set; get; } = Guid.NewGuid().ToString();
        public string SupporterName { set; get; }
        public string SupporterActivity { set; get; }
        public string SupporterMail { set; get; }
        public string SupporterNumber { set; get; }
        public string SupporterAddress { set; get; }
        public string SupporterImage { set; get; }
        public string SupporterDescription { set; get; }
    }
}
