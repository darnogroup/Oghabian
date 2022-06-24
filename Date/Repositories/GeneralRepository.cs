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
    public class GeneralRepository:IGeneralInterface
    {
        private readonly DataBaseContext _context;

        public GeneralRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryEntity>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<List<MealEntity>> GetMeals()
        {
            return await _context.Meal.ToListAsync();
        }

        public async Task<List<SicknessEntity>> GetSickness()
        {
            return await _context.Sickness.ToListAsync();
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
                ChatEntity chat=new ChatEntity();
                chat.Time=DateTime.Now;
                chat.ConnectionClient = connection;
              await  _context.Chat.AddAsync(chat);
              await _context.SaveChangesAsync();
              return chat.ChatId;
            }
        }

        public async Task<string> GetChatGroupKey(string connection)
        {
            var chat= await _context.Chat.SingleOrDefaultAsync(a => a.ConnectionClient == connection);
            return chat.ChatId;
        }

        public void SaveMessage(ChatMessageEntity message)
        {
            _context.ChatMessage.Add(message);
            _context.SaveChanges();
        }
    }
}
