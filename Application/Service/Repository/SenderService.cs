using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Application.Service.Interface;

namespace Application.Service.Repository
{
   public  class SenderService:ISenderService
    {
        public void SendMail(string receiver, string body, string subject)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("registertetronjob@gmail.com");
            mail.To.Add(receiver);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("registertetronjob@gmail.com", "@Job2022");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }

        public void SendSms(string number, string text)
        {
            //var smsInfo = await _setting.GetSetting();
            //try
            //{
            //    var sender = smsInfo.ApiNumber;
            //    KavenegarApi api = new KavenegarApi(smsInfo.ApiSms);

            //    await api.Send(sender, number, code);
            //    return true;
            //}
            //catch (Exception e)
            //{

            //    return false;
            //}
        }
    }
}
