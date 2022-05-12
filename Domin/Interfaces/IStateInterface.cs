using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IStateInterface
    {
        Task<IEnumerable<StateEntity>> GetStates(string search, int skip);
        Task<StateEntity> GetStateById(string id);
        void InsertState(StateEntity state);
        void UpdateState(StateEntity state);
        void DeleteState(StateEntity state);
        int CountState();
    }
}
