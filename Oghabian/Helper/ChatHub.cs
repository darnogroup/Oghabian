using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Home;
using Application.ViewModel.Setting;
using Domin.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Oghabian.Helper
{
    public class ChatHub:Hub
    {
        private readonly IHomeService _home;

        public ChatHub(IHomeService home)
        {
            _home = home;
        }
        public override async Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated&& Context.User.IsInRole("Admin"))
            {
                await base.OnConnectedAsync();
                return;
            }
         
            var roomKey =await _home.CreateChatGroup(Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomKey);
            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            var roomKey = await _home.GetChatGroupKey(Context.ConnectionId);
            InsertChatMessageViewModel text =new InsertChatMessageViewModel()
            {
                Sender = "کاربر سایت",
                GroupKey = roomKey,
                Message = message
            };
            _home.InsertChatMessage(text);
            await Clients.Group(roomKey).SendAsync("ReceiveMessage", user, message,DateTime.Now.LocalTime());

        }
        [Authorize(Roles = "Admin")]
        public async Task JoinGroup(string keyGroup)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, keyGroup);
        }
        [Authorize(Roles = "Admin")]
        public async Task LeftGroup(string keyGroup)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, keyGroup);
        }
    }
}
