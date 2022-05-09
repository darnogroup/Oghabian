using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class StateEntity
    {
        public string StateId { set; get; } = Guid.NewGuid().ToString();
        public string StateName { set; get; }
        public IEnumerable<CityEntity>Cities { set; get; }
        public IEnumerable<AddressEntity> Address { set; get; }
    }
}
