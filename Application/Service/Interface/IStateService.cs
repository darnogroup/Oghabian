using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.State;

namespace Application.Service.Interface
{
    public interface IStateService
    {
        Tuple<List<StateViewModel>, int, int> GetStates(int page, string search = "");

        Task<UpdateStateViewModel> GetStateById(string id);
        bool InsertState(InsertStateViewModel model);
        bool UpdateState(UpdateStateViewModel model);

        bool DeleteState(string id);
    }
}
