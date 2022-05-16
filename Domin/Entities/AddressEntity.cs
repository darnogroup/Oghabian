using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class AddressEntity
    {
        public string AddressId { set; get; } = Guid.NewGuid().ToString();
        public string AddressText { set; get; }
        public string AddressCode { set; get; }
        public string StateId { set; get; }
        public StateEntity State { set; get; }
        public string CityId { set; get; }
        public CityEntity City { set; get; }
        public string UserId { set; get; }
        public UserEntity User { set; get; }
    }
}
