using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Home.Profile;
using Application.ViewModel.Ticket;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class TicketService:ITicketService
    {
        private readonly ITicketInterface _ticket;

        public TicketService(ITicketInterface ticket)
        {
            _ticket = ticket;
        }
        public Tuple<List<TicketViewModel>, int, int> GetTickets(int page = 1, string search = "")
        {
            int pageSelected = page;
            int count = _ticket.Count().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _ticket.GetAllTicket(search, pageSkip).Result;
            List<TicketViewModel> tickets = new List<TicketViewModel>();
            foreach (var item in list)
            {
                tickets.Add(new TicketViewModel()
                {
                    TicketTitle = item.TicketTitle,
                    TicketId = item.TicketId,
                 Status = item.Status,
                 TicketTime = item.CreateTime.SolarYear(),
                 Avatar=item.User.UserAvatar,
                 UserName = item.User.UserFullName
                });
            }
            return Tuple.Create(tickets, count, pageSelected);
        }

        public async Task<List<MessageViewModel>> GetSubTickets(string ticketId)
        {
            var result = await _ticket.GetSubTicket(ticketId);
            var list = result.OrderByDescending(o => o.Time).ToList();
            List<MessageViewModel> subTicket = new List<MessageViewModel>();
            foreach (var item in list)
            {
                subTicket.Add(new MessageViewModel()
                {
                    Path = item.File,
                    Text = item.Text,
                    UserId = item.UserId
                });
            }

            return subTicket;
        }

        public void CreateSubTicket(InsertTicketDetailViewModel model)
        {
            TicketDetailEntity detail = new TicketDetailEntity();
            detail.Time = DateTime.Now;
            detail.UserId = model.UserId;
            detail.Text = model.Text;
            detail.TicketId = model.Id;
            if (model.DocumentFile != null)
            {
                var check = model.DocumentFile.IsImage();
                if (check)
                {
                    detail.File = ImageProcessing.SaveImage(model.DocumentFile);
                }
            }

            _ticket.CreateSub(detail);
        }
    }
}

