using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.State;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class StateService:IStateService
    {
        private readonly IStateInterface _state;

        public StateService(IStateInterface state)
        {
            _state = state;
        }
        public Tuple<List<StateViewModel>, int, int> GetStates(int page, string search = "")
        {
            int pageSelected = page;
            int count = _state.CountState().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list =_state.GetStates(search, pageSkip).Result;
            List<StateViewModel> state = new List<StateViewModel>();

            foreach (var item in list)
            {
                state.Add(new StateViewModel()
                {
                    StateId = item.StateId,
                    StateTitle = item.StateName
                });
            }
            return Tuple.Create(state, count, pageSelected);
        }

        public async Task<UpdateStateViewModel> GetStateById(string id)
        {
            var result = await _state.GetStateById(id);
            UpdateStateViewModel state=new UpdateStateViewModel();
            state.StateId = result.StateId;
            state.StateName = result.StateName;
            return state;
        }

        public bool InsertState(InsertStateViewModel model)
        {
           StateEntity state=new StateEntity()
           {
               StateName = model.StateName
           };
           try
           {
                _state.InsertState(state);
                return true;
           }
           catch
           {
               return false;
           }
        }

        public bool UpdateState(UpdateStateViewModel model)
        {
            var state = _state.GetStateById(model.StateId).Result;
            state.StateName = model.StateName;
            try
            {
                _state.UpdateState(state);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteState(string id)
        {
            var state = _state.GetStateById(id).Result;
            try
            {
                _state.DeleteState(state);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
