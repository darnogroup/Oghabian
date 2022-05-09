using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class CityEntity
    {
        public string CityId { set; get; } = Guid.NewGuid().ToString();
        public string CityName { set; get; }
        public string StateId { set; get; }
        public StateEntity State { set; get; }
        public IEnumerable<AddressEntity>Address { set; get; }
    }
}
