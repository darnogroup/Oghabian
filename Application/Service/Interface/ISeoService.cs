using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Seo;

namespace Application.Service.Interface
{
    public interface ISeoService
    {
        Task<SeoViewModel> GetSeoViewModel();
        void ChangeSeo(SeoViewModel model);
    }
}
