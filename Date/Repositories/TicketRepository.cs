using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date.Context;
using Date.Migrations;
using Domin.Entities;
using Domin.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories
{
    public class TicketRepository:ITicketInterface
    {
        private readonly DataBaseContext _context;

        public TicketRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TicketEntity>> GetAllTicket(string search, int skip)
        {
            return await _context.Ticket.OrderByDescending(o => o.TicketId)
                .Include(i => i.User)
                .Where(w => w.TicketTitle.ToLower().Contains(search)).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<TicketEntity>> GetUserTickets(string id)
        {
            return await _context.Ticket.Where(w => w.UserId == id).ToListAsync();
        }

        public async Task<IEnumerable<TicketDetailEntity>> GetSubTicket(string id)
        {
            return await _context.TicketDetail.Where(w => w.TicketId == id).Include(i => i.User).

                Include(i => i.Ticket).
                ToListAsync();
        }

        public void Create(TicketEntity model)
        {
            _context.Ticket.Add(model); Save();
        }

        public void CreateSub(TicketDetailEntity model)
        {
            _context.TicketDetail.Add(model); Save();
        }

        public void Update(TicketEntity model)
        {
            _context.Update(model); Save();
        }

        public async Task<TicketEntity> GetById(string id)
        {
            return await _context.Ticket.FindAsync(id);
        }

     
     
        public int Count()
        {
            return _context.Ticket.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
