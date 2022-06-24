using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date.Context;
using Domin.Entities;
using Domin.Enum;
using Domin.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories
{
   public class RegisteredOrder:IRegisteredOrderInterface
   {
       private readonly DataBaseContext _context;

       public RegisteredOrder(DataBaseContext context)
       {
           _context = context;
       }
        public async Task<List<OrderEntity>> GetRegisterOrders(string search, int skip)
        {
            return await _context.Order.Include(i=>i.User).OrderByDescending(o=>o.DateTime).Where(w => w.Condition == ConditionEnum.Record &&
                                                   w.Code.Contains(search)).Skip(skip).Take(10).ToListAsync();
        }

        public int Register()
        {
            return _context.Order.Count(c => c.Condition == ConditionEnum.Record);
        }

        public async Task<List<OrderEntity>> GetPreparationOrders(string search, int skip)
        {
            return await _context.Order.Include(i => i.User).OrderByDescending(o => o.DateTime).Where(w => w.Condition == ConditionEnum.Preparation &&
                                                                                                           w.Code.Contains(search)).Skip(skip).Take(10).ToListAsync();
        }

        public int Preparation()
        {
            return _context.Order.Count(c => c.Condition == ConditionEnum.Preparation);
        }

        public async Task<List<OrderEntity>> GetDeliveryOrders(string search, int skip)
        {
            return await _context.Order.Include(i => i.User).OrderByDescending(o => o.DateTime).Where(w => w.Condition == ConditionEnum.Delivery &&
                                                                                                           w.Code.Contains(search)).Skip(skip).Take(10).ToListAsync();
        }

        public int Delivery()
        {
            return _context.Order.Count(c => c.Condition == ConditionEnum.Delivery);
        }

        public async Task<List<OrderEntity>> GetCloseOrders(string search, int skip)
        {
            return await _context.Order.Include(i => i.User).OrderByDescending(o => o.DateTime).Where(w => w.Condition == ConditionEnum.Close &&
                                                                                                           w.Code.Contains(search)).Skip(skip).Take(10).ToListAsync();
        }

        public int Close()
        {
            return _context.Order.Count(c => c.Condition == ConditionEnum.Close);
        }

        public async Task<List<OrderDetailEntity>> GetDetails(string id)
        {
            return await _context.OrderDetail.Where(w => w.OrderId == id)
                .Include(i => i.Food).ThenInclude(t=>t.Meal)
                .Include(i=>i.Food).ThenInclude(t=>t.Sickness)
                .ToListAsync();
        }

        public async Task<string> GetUserOrder(string order)
        {
            return await _context.Order.Where(w => w.OrderId == order).Select(s => s.UserId)
                .SingleOrDefaultAsync();
        }

        public async Task<UserEntity> GetInfoUser(string user)
        {
            return await _context.Users.Include(i => i.MedicalInformation).ThenInclude(t=>t.Sickness)
                .Include(i => i.Address).ThenInclude(t=>t.City)
                .ThenInclude(t=>t.State)
                .SingleOrDefaultAsync(s => s.Id == user);
        }
   }
}
