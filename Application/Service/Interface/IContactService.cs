using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Contact;
using Application.ViewModel.Home;

namespace Application.Service.Interface
{
    public interface IContactService
    {
        Tuple<List<ContactUsViewModel>, int, int> GetMessages(int page = 1, string search = "");
        Task<ContactDetailViewModel> GetMessageById(string id);
        void DeleteMessage(string id);
    }
}
