using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ITicketInterface
    {
        Task<IEnumerable<TicketEntity>> GetAllTicket(string search, int skip);
        Task<IEnumerable<TicketEntity>> GetUserTickets(string id);
        Task<IEnumerable<TicketDetailEntity>> GetSubTicket(string id);
        void Create(TicketEntity model);
        void CreateSub(TicketDetailEntity model);
        void Update(TicketEntity model);
        Task<TicketEntity> GetById(string id);
   
        int Count();
    }
}
