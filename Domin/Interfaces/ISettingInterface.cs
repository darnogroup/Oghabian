using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ISettingInterface
    {
        Task<string> CreateChatGroup(string connection);
        Task<string> GetChatGroupKey(string connection);
        Task<List<ChatEntity>> GetRooms();
        Task<List<ChatMessageEntity>> GetMessageByRoomId(string room);
        Task<SettingEntity> GetSetting();
        void Update(SettingEntity model);
        void Insert(SettingEntity model);
        void Save();
    }
}
