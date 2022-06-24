using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Discount;
using Application.ViewModel.Link;

namespace Application.Service.Interface
{
    public interface IDiscountService
    {
        Tuple<List<DiscountViewModel>, int, int> GetDiscounts(int page, string search = "");
        Task<UpdateDiscountViewModel> GetDiscountById(string id);
        bool InsertDiscount(InsertDiscountViewModel model);
        bool UpdateDiscount(UpdateDiscountViewModel model);
        bool DeleteDiscount(string id);
    }
}
