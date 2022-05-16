using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Enum;
using Microsoft.AspNetCore.Identity;

namespace Domin.Entities
{
    public class UserEntity:IdentityUser
    {
        public string UserFullName { set; get; }
        public string Role { set; get; }
        public string LoginCode { set; get; }
        public string UserAvatar { set; get; }
        public string LoginKey { set; get; }
        public bool MedicalRecords { set; get; }
        public DateTime Time { set; get; }=DateTime.Now;
        public IEnumerable<FavoriteEntity>Favorite { set; get; }
        public IEnumerable<CommentArticleEntity>CommentArticle { set; get; }
        public IEnumerable<CommentFoodEntity>CommentFood { set; get; }
       public AddressEntity Address { set; get; }
       public MedicalInformationEntity MedicalInformation { set; get; }
       public IEnumerable<OrderEntity>Order { set; get; }
    }
}
