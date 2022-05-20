using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IContactInterface
    {
        Task<IEnumerable<ContactEntity>> GetContacts(string search, int skip);
        Task<ContactEntity> GetContactById(string id);
        int Count();
        void Insert(ContactEntity contact);
        void Update(ContactEntity contact);
        void Remove(ContactEntity contact);
    }
}
