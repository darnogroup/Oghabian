using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Home.Profile
{
    public class AddNewTicketViewModel
    {
        public IFormFile TicketFile { set; get; }

        [Required(ErrorMessage = "متن تیک الزامی است")]
        public string TicketBody { set; get; }
        public string UserId { set; get; }
        public string Id { set; get; }
    }
}
