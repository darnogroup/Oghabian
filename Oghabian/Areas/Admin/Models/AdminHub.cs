using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Home;
using Domin.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Oghabian.Helper;

namespace Oghabian.Areas.Admin.Models
{
    [Authorize(Roles = "Admin")]
    public class AdminHub:Hub
    {
        private readonly ISettingService _setting;
        private readonly IHomeService _home;
        private readonly IHubContext<ChatHub> _hub;
        private readonly UserManager<UserEntity> _user;

        public AdminHub(ISettingService setting, IHomeService home, IHubContext<ChatHub> hub, UserManager<UserEntity> user)
        {
            _setting = setting;
            _home = home;
            _hub = hub;
            _user = user;
        }

        public override async Task OnConnectedAsync()
        {
             var groups =await _setting.GetRooms();
             await Clients.Caller.SendAsync("GatRoom", groups);
             await base.OnConnectedAsync();
        }

        public async Task SendToClient(string keyGroup,string text)
        {
            var user = _user.FindByIdAsync(Context.User.FindFirstValue(ClaimTypes.NameIdentifier)).Result.UserFullName ;
            InsertChatMessageViewModel chat=new InsertChatMessageViewModel();
            chat.Message = text;
            chat.GroupKey = keyGroup;
            chat.Sender = user;
             _home.InsertChatMessage(chat);
             await _hub.Clients.Group(keyGroup).SendAsync("SupportMessage", user,text,DateTime.Now.LocalTime());
             await Clients.Caller.SendAsync("AdminSend", Context.User.Identity.Name, text, DateTime.Now.LocalTime());
        }
        public async Task LoadChat(string id)
        {
            var messages =await _setting.GetMessages(id);
            await Clients.Caller.SendAsync("Load", messages);
        }
    }
}
