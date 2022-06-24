using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Home.Profile;
using Application.ViewModel.Selection;
using Application.ViewModel.User;
using Domin.Entities;
using Domin.Enum;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class ProfileService:IProfileService
    {
        private readonly IProfileInterface _profile;
        private readonly IUserInterface _user;
        private readonly IOrderInterface _order;
        private readonly ITicketInterface _ticket;

        public ProfileService(IProfileInterface profile, IUserInterface user, IOrderInterface order, ITicketInterface ticket)
        {
            _profile = profile;
            _user = user;
            _order = order;
            _ticket = ticket;
        }
        public async Task<List<SelectViewModel>> GetState()
        {
            var states = await _profile.GetState();
            List<SelectViewModel> models=new List<SelectViewModel>();
            foreach (var item in states)
            {
                models.Add(new SelectViewModel()
                {
                    Text=item.StateName,
                    Value = item.StateId
                });
            }

            return models;
        }

        public async Task<List<SelectViewModel>> GetCity(string id)
        {
            var cities = await _profile.GetCities(id);
            List<SelectViewModel> models = new List<SelectViewModel>();
            foreach (var item in cities)
            {
                models.Add(new SelectViewModel()
                {
                    Text = item.CityName,
                    Value = item.CityId
                });
            }

            return models;
        }

        public async Task<AddressViewModel> GetAddress(string id)
        {
            var address =await _profile.GetAddress(id);
            AddressViewModel model=new AddressViewModel();
            if (address != null)
            {
                model.StateId = address.StateId;
                model.AddressCode = address.AddressCode;
                model.AddressText = address.AddressText;
                model.CityId = address.CityId;
            }
            else
            {
                model.StateId = "";
                model.AddressCode = "";
                model.AddressText = "";
                model.CityId = "";
            }

            return model;
        }

        public void UpdateAddress(AddressViewModel address)
        {
            var model = _profile.GetAddress(address.UserId).Result;
            if (model == null)
            {
                AddressEntity entity=new AddressEntity();
                entity.StateId = address.StateId;
                entity.AddressCode = address.AddressCode;
                entity.AddressText = address.AddressText;
                entity.CityId = address.CityId;
                entity.UserId = address.UserId;
                _profile.InsertAddress(entity);
            }
            else
            {
                model.StateId = address.StateId;
                model.AddressCode = address.AddressCode;
                model.AddressText = address.AddressText;
                model.CityId = address.CityId;
                _profile.UpdateAddress(model);
            }
        }

        public async Task<List<FavoriteViewModel>> GetUserFavorite(string id)
        {
            var result = await _profile.GetFavorites(id);
            List<FavoriteViewModel>favorite=new List<FavoriteViewModel>();
            foreach (var item in result)
            {
                favorite.Add(new FavoriteViewModel()
                {
                    FoodCalories = item.Food.FoodCalories.ToString(),
                    FoodCarbohydrate = item.Food.FoodCarbohydrate,
                    FoodFat = item.Food.FoodFat,
                    FoodProtein = item.Food.FoodProtein,
                    FavoriteId = item.FavoriteId,
                    FoodId = item.FoodId,
                    Image = item.Food.FoodImage,
                    Title = item.Food.FoodTitle
                });
            }

            return favorite;
        }

        public void AddFavorite(AddFavoriteViewModel model)
        {
            var check = _profile.Exist(model.UserId, model.FoodId);
            if(check==false)
            {
                FavoriteEntity favorite = new FavoriteEntity();
                favorite.FoodId = model.FoodId;
                favorite.UserId = model.UserId;
                _profile.AddFavorite(favorite);
            }
          
        }

        public void DeleteFavorite(string favoriteId)
        {
            var model = _profile.GetFavoriteById(favoriteId).Result;
            _profile.DeleteFavorite(model);
        }

        public async Task<List<OrderHistoryViewModel>> OrderHistory(string user)
        {
            var orders = await _order.GetUserOrders(user);
            List<OrderHistoryViewModel>history=new List<OrderHistoryViewModel>();
            foreach (var item in orders)
            {
               history.Add(new OrderHistoryViewModel()
               {
                   Condition = ConvertEnum.ConditionToViewModel(item.Condition),
                   Code = item.Code,
                   Id = item.OrderId,
                   Time = item.DateTime.SolarYear()
               }); 
            }

            return history;
        }

        public async Task<List<DetailHistoryViewModel>> GetDetail(string id)
        {
            var detail = await _order.GetDetailById(id);
            List<DetailHistoryViewModel>history=new List<DetailHistoryViewModel>();
            foreach (var item in detail)
            {
                history.Add(new DetailHistoryViewModel()
                {
                     Count = item.Count.ToString(),
                     Image = item.Food.FoodImage,
                     Price = item.Price.ToString("#,0"),
                     Title = item.Food.FoodTitle
                });
            }

            return history;
        }

        public void AddTicket(AddTicketViewModel model)
        {
            TicketEntity ticket=new TicketEntity();
            ticket.UserId = model.UserId;
            ticket.TicketTitle = model.TicketTitle;
            ticket.Status = MessageStatus.Wait;
            ticket.CreateTime=DateTime.Now;
            _ticket.Create(ticket);
            TicketDetailEntity detail=new TicketDetailEntity();
            detail.Time=DateTime.Now;
            detail.UserId = model.UserId;
            detail.Text = model.TicketBody;
            detail.TicketId = ticket.TicketId;
            if (detail.File != null)
            {
                var check = model.TicketFile.IsImage();
                if (check)
                {
                    detail.File = ImageProcessing.SaveImage(model.TicketFile);
                }
            }
            _ticket.CreateSub(detail);
        }

        public async Task<List<TicketsViewModel>> GetUserTicket(string user)
        {
            List<TicketsViewModel>tickets=new List<TicketsViewModel>();
            var result = await _ticket.GetUserTickets(user);
            foreach (var item in result)
            {
                tickets.Add(new TicketsViewModel()
                {
                    TicketTitle = item.TicketTitle,
                    Status = item.Status,
                    TicketId = item.TicketId,
                    TicketTime = item.CreateTime.SolarYear()
                });
            }

            return tickets;
        }

        public async Task<List<TicketMessageViewModel>> GetMessages(string ticket)
        {
            var result = await _ticket.GetSubTicket(ticket);
            var list = result.OrderByDescending(o => o.Time).ToList();
            List<TicketMessageViewModel>message=new List<TicketMessageViewModel>();
            foreach (var item in list)
            {
                message.Add(new TicketMessageViewModel()
                {
                    Path = item.File,
                    Text = item.Text,
                    UserId = item.UserId
                });
            }

            return message;
        }

        public void AddNewTicket(AddNewTicketViewModel model)
        {
       TicketDetailEntity detail = new TicketDetailEntity();
            detail.Time = DateTime.Now;
            detail.UserId = model.UserId;
            detail.Text = model.TicketBody;
            detail.TicketId = model.Id;
            if (model.TicketFile != null)
            {
                var check = model.TicketFile.IsImage();
                if (check)
                {
                    detail.File = ImageProcessing.SaveImage(model.TicketFile);
                }
            }

            _ticket.CreateSub(detail);

        }

        public async Task<bool> RunDiscount(string code, string user)
        {
            var order =await _order.GetOrderByUserId(user);
            if (order.Discount != true)
            {
                var codeCheck = await _profile.ExistDiscount(code);
                if (codeCheck)
                {
                    var discountPrice = await _profile.GetWithCode(code);
                    var price = Convert.ToInt32(discountPrice.DiscountPrice);
                    order.Total = order.Total - price;
                    order.Discount = true;
                    _order.UpdateOrder(order);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<string> FinishOrder(string user)
        {
            var order = await _order.GetOrderByUserId(user);
            order.Close = true;
            order.PaymentOnTheSpot = true;
            order.Condition = ConvertEnum.ConditionToModel(ConditionEnumViewModel.Record);
            _order.UpdateOrder(order);
            return order.Code;
        }
    }
}
