using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.RegisterOrder;

namespace Application.Service.Interface
{
    public interface IRegisteredOrderService
    {
        Tuple<List<RegisterViewModel>, int, int> GetRegisters(int page = 1, string search = "");
        Tuple<List<RegisterViewModel>, int, int> GetPreparations(int page = 1, string search = "");
        Tuple<List<RegisterViewModel>, int, int> GetDeliveries(int page = 1, string search = "");
        Tuple<List<RegisterViewModel>, int, int> GetCloses(int page = 1, string search = "");
        Tuple<List<RegisterItemViewModel>, InfoUserRegisterViewModel> GetDetailById(string id);
        void KitchenReady(string order);
        void KitchenFinish(string order);
        void Delivery(string order);
        bool DeleteOrder(string order);
    }
}
