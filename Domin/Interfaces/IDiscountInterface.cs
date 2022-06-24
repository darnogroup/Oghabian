using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IDiscountInterface
    {
        Task<IEnumerable<DiscountEntity>> GetDiscounts(string search, int skip);
        Task<DiscountEntity> GetDiscountById(string id);
        void InsertDiscount(DiscountEntity discount);
        void UpdateDiscount(DiscountEntity discount);
        void DeleteDiscount(DiscountEntity discount);
        int CountDiscount();
    }
}
