using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Enum;

namespace Domin.Entities
{
    public class MedicalInformationEntity
    {
        public string Id { set; get; } = Guid.NewGuid().ToString();
        public string UserHeight { set; get; }
        public string UserWeight { set; get; }
        public Gender UserGender { set; get; }
        public string UserAge { set; get; }
        public string MedicalRecords { set; get; }
        public string UserId { set; get; }
        public UserEntity User { set; get; }
        public string SicknessId { set; get; }
        public SicknessEntity Sickness { set; get; }
        public string UserCalories { set; get; }
        public string UserCarbohydrate { set; get; }
        public string UserFat { set; get; }
        public string UserProtein { set; get; }
    }
}
