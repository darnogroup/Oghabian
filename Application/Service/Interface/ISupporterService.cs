using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Supporter;

namespace Application.Service.Interface
{
     public interface ISupporterService
    {
        Tuple<List<SupporterViewModel>, int, int> GetSupporters(int page, string search = "");
        Task<UpdateSupporterViewModel> GetSupporterById(string id);
        bool InsertSupporter(InsertSupporterViewModel model);
        bool UpdateSupporter(UpdateSupporterViewModel model);
        bool DeleteSupporter(string id);
 
    }
}
