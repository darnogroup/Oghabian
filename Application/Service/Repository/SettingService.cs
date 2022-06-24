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
                model.Description = setting.Description;
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
                model.SendPrice = setting.SendPrice;
                model.Law = setting.Law;
            }
            else
            {
                model.SendPrice = "";
                model.Law = "";
                model.Description = "";
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
                entity.Description = model.Description;
                entity.SendPrice = model.SendPrice;
                entity.Law = model.Law;
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
                setting.Description = model.Description;
                setting.ApiSms = model.ApiSms;
                setting.ApiNumber = model.ApiNumber;
                setting.Bank = model.Bank;
                setting.Instagram = model.Instagram;
                setting.Linkdin = model.Linkdin;
                setting.Mail = model.Mail;
                setting.TitleSite = model.TitleSite;
                setting.Number = model.Number;
                setting.SendPrice = model.SendPrice;
                setting.Law = model.Law;
                setting.WhatsApp = model.WhatsApp;
                setting.FaceBook = model.FaceBook;
                setting.Address = model.Address;
                _setting.Update(setting);
            }
        }

        public async Task<string> CreateChatGroup(string connection)
        {
            return await _setting.CreateChatGroup(connection);
        }

        public async Task<string> GetChatGroupKey(string connection)
        {
            return await _setting.GetChatGroupKey(connection);
        }

        public async Task<List<ChatViewModel>> GetRooms()
        {
            var result = await _setting.GetRooms();
            List<ChatViewModel>chat=new List<ChatViewModel>();
            foreach (var item in result)
            {
                chat.Add(new ChatViewModel()
                {
                    ConnectionClient = item.ConnectionClient,
                    ChatId = item.ChatId
                });
            }

            return chat;
        }

        public async Task<List<ChatMessageViewModel>> GetMessages(string room)
        {
            var result = await _setting.GetMessageByRoomId(room);
            List<ChatMessageViewModel>messages=new List<ChatMessageViewModel>();
            foreach (var item in result)
            {
                 messages.Add(new ChatMessageViewModel()
                 {
                     Id = item.Id,
                     Text = item.Text,Sender = item.Sender,
                     Time = item.Time.LocalTime()
                 });
            }

            return messages;
        }
    }
}
