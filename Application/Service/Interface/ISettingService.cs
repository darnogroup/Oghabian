using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Setting;

namespace Application.Service.Interface
{
    public interface ISettingService
    {
        Task<SettingViewModel> GetSettingViewModel();
        void ChangeSetting(SettingViewModel model);
        Task<string> CreateChatGroup(string connection);
        Task<string> GetChatGroupKey(string connection);
        Task<List<ChatViewModel>> GetRooms();
        Task<List<ChatMessageViewModel>> GetMessages(string room);
    }
}
