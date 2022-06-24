using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date.Context;
using Domin.Entities;
using Domin.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories
{
    public class SettingRepository:ISettingInterface
    {
        private readonly DataBaseContext _context;

        public SettingRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<List<ChatEntity>> GetRooms()
        {
            return await _context.Chat.Include(i=>i.Message).Where(w=>w.Message.Any()).ToListAsync();
        }

        public async Task<List<ChatMessageEntity>> GetMessageByRoomId(string room)
        {
            return await _context.ChatMessage.Where(w => w.ChatId == room).ToListAsync();
        }

        public async Task<SettingEntity> GetSetting()
        {
            return await _context.Setting.FirstOrDefaultAsync();
        }

        public void Update(SettingEntity model)
        {
            _context.Update(model);Save();
        }

        public void Insert(SettingEntity model)
        {
            _context.Setting.Add(model); Save();
        }
        public async Task<string> CreateChatGroup(string connection)
        {
            var check = await _context.Chat.SingleOrDefaultAsync(a => a.ConnectionClient == connection);
            if (check != null)
            {
                return check.ChatId;
            }
            else
            {
                ChatEntity chat = new ChatEntity();
                chat.ConnectionClient = connection;
                await _context.Chat.AddAsync(chat);
                await _context.SaveChangesAsync();
                return chat.ChatId;
            }
        }

        public async Task<string> GetChatGroupKey(string connection)
        {
            var chat = await _context.Chat.SingleOrDefaultAsync(a => a.ConnectionClient == connection);
            return chat.ChatId;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
