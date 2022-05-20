using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Ticket
{
    public class InsertTicketDetailViewModel
    {
        public string Id { set; get; }
        public string UserId { set; get; }
        public string Text { set; get; }
        public IFormFile DocumentFile { set; get; }
    }
}
