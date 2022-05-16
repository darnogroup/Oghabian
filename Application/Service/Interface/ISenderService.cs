using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface ISenderService
    {
        void SendMail(string receiver, string body, string subject);
        void SendSms(string number, string text);
    }
}
