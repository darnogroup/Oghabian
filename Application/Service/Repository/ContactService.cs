using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Contact;
using Application.ViewModel.Home;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class ContactService:IContactService
    {
        private readonly IContactInterface _contact;

        public ContactService(IContactInterface contact)
        {
            _contact = contact;
        }

        public Tuple<List<ContactUsViewModel>, int, int> GetMessages(int page = 1, string search = "")
        {
            int pageSelected = page;
            int count = _contact.Count().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _contact.GetContacts(search, pageSkip).Result;
            List<ContactUsViewModel> message = new List<ContactUsViewModel>();

            foreach (var item in list)
            {
                message.Add(new ContactUsViewModel()
                {
                    Id = item.Id,
                    Mail = item.Mail,
                    Name = item.Name,
                    Time = item.Time.SolarYear()
                });
            }
            return Tuple.Create(message, count, pageSelected);
        }

        public async Task<ContactDetailViewModel> GetMessageById(string id)
        {
            var result = await _contact.GetContactById(id);
            ContactDetailViewModel detail=new ContactDetailViewModel()
            {
               
                Mail = result.Mail,
                Name = result.Name,
                Time = result.Time.SolarYear(),
                Body = result.Body,
                Number = result.PhoneNumber
            };
            return detail;
        }

        public void DeleteMessage(string id)
        {
            var result =  _contact.GetContactById(id).Result;
            _contact.Remove(result);
        }
    }
}
