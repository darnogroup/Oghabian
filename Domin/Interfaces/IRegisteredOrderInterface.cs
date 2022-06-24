using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IRegisteredOrderInterface
    {
        Task<List<OrderEntity>> GetRegisterOrders(string search, int skip);
        int Register();
        Task<List<OrderEntity>> GetPreparationOrders(string search, int skip);
        int Preparation();
        Task<List<OrderEntity>> GetDeliveryOrders(string search, int skip);
        int Delivery();  
        Task<List<OrderEntity>> GetCloseOrders(string search, int skip);
        int Close();
        Task<List<OrderDetailEntity>> GetDetails(string id);
        Task<string> GetUserOrder(string order);
        Task<UserEntity> GetInfoUser(string user);
    }
}
