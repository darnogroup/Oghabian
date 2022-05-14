using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Setting;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class SettingService:ISettingService
    {
        private readonly ISettingInterface _setting;

        public SettingService(ISettingInterface setting)
        {
            _setting = setting;
        }
        public  async  Task<SettingViewModel> GetSettingViewModel()
        {
            var setting = await _setting.GetSetting();
            SettingViewModel model = new SettingViewModel();
            if (setting != null)
            {
                model.Instagram = setting.Instagram;
                model.Linkdin = setting.Linkdin;
                model.Mail = setting.Mail;
                model.Number = setting.Number;
                model.WhatsApp = setting.WhatsApp;
                model.FaceBook = setting.FaceBook;
                model.Address = setting.Address;
                model.TitleSite = setting.TitleSite;
                model.LogoPath = setting.Logo;
                model.Bank = setting.Bank;
                model.ApiNumber = setting.ApiNumber;
                model.ApiSms = setting.ApiSms;
            }
            else
            {
                model.TitleSite = "";
                model.ApiNumber = "";
                model.ApiSms = "";
                model.Bank = "";
                model.Instagram = "";
                model.Linkdin = "";
                model.Mail = "";
                model.Number = "";
                model.WhatsApp = "";
                model.FaceBook = "";
                model.Address = "";
                model.LogoPath = "notFound.png";
            }
            return model;
        }

        public void ChangeSetting(SettingViewModel model)
        {
            var setting = _setting.GetSetting().Result;
            if (setting == null)
            {
                SettingEntity entity = new SettingEntity();
                entity.Instagram = model.Instagram;
                entity.Linkdin = model.Linkdin;
                entity.Mail = model.Mail;
                entity.Number = model.Number;
                entity.WhatsApp = model.WhatsApp;
                entity.FaceBook = model.FaceBook;
                entity.TitleSite = model.TitleSite;
                entity.Address = model.Address;
                entity.ApiSms = model.ApiSms;
                entity.ApiNumber = model.ApiNumber;
                entity.Bank = model.Bank;
                
                if (model.Logo != null)
                {
                    var checkImage = model.Logo.IsImage();
                    entity.Logo = checkImage ? ImageProcessing.SaveImage(model.Logo) : "notFound.png";
                }
              
                _setting.Insert(entity);
            }
            else
            {
                if (model.Logo != null)
                {
                    var checkImage = model.Logo.IsImage();
                    if (checkImage)
                    {
                        setting.Logo = ImageProcessing.SaveImage(model.Logo);
                        if (model.LogoPath != "notFound.png")
                        {
                            ImageProcessing.RemoveImage(model.LogoPath);
                        }

                    }
                }
                setting.ApiSms = model.ApiSms;
                setting.ApiNumber = model.ApiNumber;
                setting.Bank = model.Bank;
                setting.Instagram = model.Instagram;
                setting.Linkdin = model.Linkdin;
                setting.Mail = model.Mail;
                setting.TitleSite = model.TitleSite;
                setting.Number = model.Number;
                setting.WhatsApp = model.WhatsApp;
                setting.FaceBook = model.FaceBook;
                setting.Address = model.Address;
                _setting.Update(setting);
            }
        }
    }
}
