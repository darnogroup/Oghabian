using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Home.Profile;
using Application.ViewModel.Ticket;

namespace Application.Service.Interface
{
    public interface ITicketService
    {
        Tuple<List<TicketViewModel>, int, int> GetTickets(int page = 1, string search = "");
        Task<List<MessageViewModel>> GetSubTickets(string ticketId);
        void CreateSubTicket(InsertTicketDetailViewModel model);
    }
}
