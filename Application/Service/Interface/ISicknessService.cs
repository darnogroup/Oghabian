using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Sickness;

namespace Application.Service.Interface
{
    public interface ISicknessService
    {
        Tuple<List<SicknessViewModel>, int, int> GetSickness(int page, string search = "");

        Task<UpdateSicknessViewModel> GetSicknessById(string id);
        bool InsertSickness(InsertSicknessViewModel model);
        bool UpdateSickness(UpdateSicknessViewModel model);

        bool DeleteSickness(string id);
    }
}
