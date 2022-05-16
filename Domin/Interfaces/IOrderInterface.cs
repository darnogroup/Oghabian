using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public  interface IOrderInterface
    {
        Task<IEnumerable<OrderEntity>> GetOrders(string search, int skip);
        Task<OrderEntity> GetOrderById(string id);
        Task<OrderEntity> GetOrderByUserId(string id);
        Task<OrderDetailEntity> GetById(string id); 
        Task<OrderDetailEntity> GetExistOrderDetail(string order,string food);
        Task<IEnumerable<OrderEntity>> GetUserOrders(string id);
        Task<IEnumerable<OrderDetailEntity>> GetDetailById(string id);
        void InsertOrder(OrderEntity order);
        void UpdateOrder(OrderEntity order);   
        void InsertOrderDetail(OrderDetailEntity order);
        void UpdateOrderDetail(OrderDetailEntity order);
        void DeleteOrderDetail(OrderDetailEntity order);
        bool OpenOrder(string id);

    }
}
