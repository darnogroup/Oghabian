using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Ads;

namespace Application.Service.Interface
{
    public interface IAdsService
    {
        Task<AdsViewModel> GetAdsViewModel();
        void ChangeAds(AdsViewModel model);
    }
}
