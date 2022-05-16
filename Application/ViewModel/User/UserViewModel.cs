using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.User
{
    public class UserViewModel
    {
        public bool MedicalRecords { set; get; }
        public string UserFullName { set; get; }
        public string UserId { set; get; }
        public string UserMail { set; get; }
        public string UserAvatar { set; get; }
    }
}
