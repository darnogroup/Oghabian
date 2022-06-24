using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Link;

namespace Application.Service.Interface
{
    public interface ILinkService
    {
        Tuple<List<LinkViewModel>, int, int> GetLinks(int page, string search = "");
        Task<UpdateLinkViewModel> GetLinkById(string id);
        bool InsertLink(InsertLinkViewModel model);
        bool UpdateLink(UpdateLinkViewModel model);
        bool DeleteLink(string id);
    }
}
