using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domin.Entities
{
    public class UserEntity:IdentityUser
    {
        public string UserFullName { set; get; }
        public string UserHeight { set; get; }
        public string UserWeight { set; get; }
        public string Role { set; get; }
        public string LoginCode { set; get; }
        public string UserAvatar { set; get; }
        public string LoginKey { set; get; }
       public string Address { set; get; }
       public string AddressCode { set; get; }
       public IEnumerable<FavoriteEntity>Favorite { set; get; }
    }
}
