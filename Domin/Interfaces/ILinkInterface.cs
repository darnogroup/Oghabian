using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ILinkInterface
    {
        Task<IEnumerable<LinkEntity>> GetLinks(string search, int skip);
        Task<LinkEntity> GetLinkById(string id);
        void InsertLink(LinkEntity link);
        void UpdateLink(LinkEntity link);
        void DeleteLink(LinkEntity link);
        int CountLink();
    }
}
