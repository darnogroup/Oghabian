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
    public class OrderRepository:IOrderInterface
    {
        private readonly DataBaseContext _context;

        public OrderRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderEntity>> GetOrders(string search, int skip)
        {
            return await _context.Order.OrderByDescending(o => o.DateTime)
                .Where(w => w.Code.Contains(search)).Skip(skip).Take(10).ToListAsync();


        }

        public async Task<OrderEntity> GetOrderById(string id)
        {
            return await _context.Order.Include(i => i.User)
                .SingleOrDefaultAsync(s => s.OrderId == id);
        }

        public async Task<OrderEntity> GetOrderByUserId(string id)
        {
            return await _context.Order.Where(w=>w.Close==false).Include(i => i.User)
                .SingleOrDefaultAsync(s => s.UserId == id);
        }

        public async Task<OrderDetailEntity> GetById(string id)
        {
            return await _context.OrderDetail.Include(i => i.Food).SingleOrDefaultAsync(s => s.OrderDetailId == id);
        }

        public async Task<OrderDetailEntity> GetExistOrderDetail(string order, string food)
        {
            return await _context.OrderDetail.SingleOrDefaultAsync(s => s.FoodId == food && s.OrderId == order);
        }

        public async Task<IEnumerable<OrderEntity>> GetUserOrders(string id)
        {
            return await _context.Order.Include(i=>i.User).Where(w => w.UserId == id).ToListAsync();
        }

        public async Task<IEnumerable<OrderDetailEntity>> GetDetailById(string id)
        {
            return await _context.OrderDetail.Include(i=>i.Food).Where(w => w.OrderId == id).ToListAsync();
        }

        public void InsertOrder(OrderEntity order)
        {
            _context.Order.Add(order);Save();
        }

        public void UpdateOrder(OrderEntity order)
        {
            _context.Update(order);Save();
        }

        public void InsertOrderDetail(OrderDetailEntity order)
        {
            _context.OrderDetail.Add(order);Save();
        }

        public void UpdateOrderDetail(OrderDetailEntity order)
        {
            _context.Update(order); Save();
        }

        public void DeleteOrderDetail(OrderDetailEntity order)
        {
            _context.OrderDetail.Remove(order);Save();
        }

        public void DeleteOrder(OrderEntity order)
        {
            _context.Order.Remove(order);Save();
        }

        public bool OpenOrder(string id)
        {
            return _context.Order.Any(w => w.Close == false && w.UserId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
