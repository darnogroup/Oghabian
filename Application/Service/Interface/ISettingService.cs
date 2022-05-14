using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Setting;

namespace Application.Service.Interface
{
    public interface ISettingService
    {
        Task<SettingViewModel> GetSettingViewModel();
        void ChangeSetting(SettingViewModel model);
    }
}
