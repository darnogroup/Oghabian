using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Discount;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class DiscountService:IDiscountService
    {
        private readonly IDiscountInterface _discount;

        public DiscountService(IDiscountInterface discount)
        {
            _discount = discount;
        }
        public Tuple<List<DiscountViewModel>, int, int> GetDiscounts(int page, string search = "")
        {
            int pageSelected = page;
            int count = _discount.CountDiscount().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _discount.GetDiscounts(search, pageSkip).Result;
            List<DiscountViewModel> discount = new List<DiscountViewModel>();

            foreach (var item in list)
            {
                discount.Add(new DiscountViewModel()
                {
                DiscountTitle = item.DiscountTitle,
                DiscountCode = item.DiscountCode,
                DiscountId = item.DiscountId,
                EndTime = item.EndTime.SolarYear(),
                StartTime = item.StartTime.SolarYear()
                });
            }
            return Tuple.Create(discount, count, pageSelected);
        }

        public async Task<UpdateDiscountViewModel> GetDiscountById(string id)
        {
            var discount = await _discount.GetDiscountById(id);
            UpdateDiscountViewModel model=new UpdateDiscountViewModel();
            model.DiscountTitle = discount.DiscountTitle;
            model.DiscountCode = discount.DiscountCode;
            model.DiscountPrice = discount.DiscountPrice.ToString();
            model.Id = discount.DiscountId;
            model.StartTime = discount.StartTime.SolarYear();
            model.EndTime = discount.EndTime.SolarYear();
            return model;
        }

        public bool InsertDiscount(InsertDiscountViewModel model)
        {
           DiscountEntity discount=new DiscountEntity();
           discount.DiscountTitle = model.DiscountTitle;
           discount.DiscountCode = model.DiscountCode;
           discount.DiscountPrice = Convert.ToInt64(model.DiscountPrice);
           discount.EndTime = model.EndTime.GregorianYear();
           discount.StartTime = model.StartTime.GregorianYear();
           try
           {
                _discount.InsertDiscount(discount);
                return true;
           }
           catch
           {
               return false;
           }
        }

        public bool UpdateDiscount(UpdateDiscountViewModel model)
        {
            var discount = _discount.GetDiscountById(model.Id).Result;
            discount.DiscountTitle = model.DiscountTitle;
            discount.DiscountCode = model.DiscountCode;
            discount.DiscountPrice = Convert.ToInt64(model.DiscountPrice);
            discount.EndTime = model.EndTime.GregorianYear();
            discount.StartTime = model.StartTime.GregorianYear();
            try
            {
                _discount.UpdateDiscount(discount);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDiscount(string id)
        {
            var discount = _discount.GetDiscountById(id).Result;
            try
            {
                _discount.DeleteDiscount(discount);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
