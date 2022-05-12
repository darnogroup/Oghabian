using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date.Context;
using Domin.Entities;
using Domin.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories
{
    public class StateRepository:IStateInterface
    {
        private readonly DataBaseContext _context;

        public StateRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StateEntity>> GetStates(string search, int skip)
        {
            return await _context.State.Where(w => w.StateName.ToLower().Contains(search))
                .Skip(skip).Take(10).ToListAsync();
        }

        public async Task<StateEntity> GetStateById(string id)
        {
            return await _context.State.FindAsync(id);
        }

        public void InsertState(StateEntity state)
        {
            _context.State.Add(state);Save();
        }

        public void UpdateState(StateEntity state)
        {
            _context.Update(state);Save();
        }

        public void DeleteState(StateEntity state)
        {
            _context.State.Remove(state);Save();
        }

        public int CountState()
        {
            return _context.State.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
