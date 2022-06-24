using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.RegisterOrder;
using Domin.Enum;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class RegisterOrderService:IRegisteredOrderService
    {
        private readonly IRegisteredOrderInterface _order;
        private readonly IOrderInterface _orderInterface;

        public RegisterOrderService(IRegisteredOrderInterface order, IOrderInterface orderInterface)
        {
            _order = order;
            _orderInterface = orderInterface;
        }
        public Tuple<List<RegisterViewModel>, int, int> GetRegisters(int page = 1, string search = "")
        {
            int pageSelected = page;
            int count = _order.Register().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _order.GetRegisterOrders(search, pageSkip).Result;
            List<RegisterViewModel> order = new List<RegisterViewModel>();

            foreach (var item in list)
            {
                order.Add(new RegisterViewModel()
                {
                    Price = item.Total.ToString("#,0"),Id = item.OrderId,
                    Name = item.User.UserFullName,
                    Number = item.User.PhoneNumber,
                    Pay = item.PaymentOnTheSpot,
                    Time = item.DateTime.SolarYear()
                });
            }
            return Tuple.Create(order, count, pageSelected);
        }

        public Tuple<List<RegisterViewModel>, int, int> GetPreparations(int page = 1, string search = "")
        {
            int pageSelected = page;
            int count = _order.Preparation().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _order.GetPreparationOrders(search, pageSkip).Result;
            List<RegisterViewModel> order = new List<RegisterViewModel>();

            foreach (var item in list)
            {
                order.Add(new RegisterViewModel()
                {
                    Price = item.Total.ToString("#,0"),
                    Id = item.OrderId,
                    Name = item.User.UserFullName,
                    Number = item.User.PhoneNumber,
                    Pay = item.PaymentOnTheSpot,
                    Time = item.DateTime.SolarYear()
                });
            }
            return Tuple.Create(order, count, pageSelected);
        }

        public Tuple<List<RegisterViewModel>, int, int> GetDeliveries(int page = 1, string search = "")
        {
            int pageSelected = page;
            int count = _order.Delivery().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _order.GetDeliveryOrders(search, pageSkip).Result;
            List<RegisterViewModel> order = new List<RegisterViewModel>();

            foreach (var item in list)
            {
                order.Add(new RegisterViewModel()
                {
                    Price = item.Total.ToString("#,0"),
                    Id = item.OrderId,
                    Name = item.User.UserFullName,
                    Number = item.User.PhoneNumber,
                    Pay = item.PaymentOnTheSpot,
                    Time = item.DateTime.SolarYear(),
                    Condition = ConvertEnum.ConditionToViewModel(item.Condition)
                });
            }
            return Tuple.Create(order, count, pageSelected);
        }

        public Tuple<List<RegisterViewModel>, int, int> GetCloses(int page = 1, string search = "")
        {
            int pageSelected = page;
            int count = _order.Close().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _order.GetCloseOrders(search, pageSkip).Result;
            List<RegisterViewModel> order = new List<RegisterViewModel>();

            foreach (var item in list)
            {
                order.Add(new RegisterViewModel()
                {
                    Price = item.Total.ToString("#,0"),
                    Id = item.OrderId,
                    Name = item.User.UserFullName,
                    Number = item.User.PhoneNumber,
                    Pay = item.PaymentOnTheSpot,
                    Time = item.DateTime.SolarYear(),
                    Condition = ConvertEnum.ConditionToViewModel(item.Condition)
                });
            }
            return Tuple.Create(order, count, pageSelected);
        }

        public Tuple<List<RegisterItemViewModel>, InfoUserRegisterViewModel> GetDetailById(string id)
        {
            var userId = _order.GetUserOrder(id).Result;
            var userInfo = _order.GetInfoUser(userId).Result;
            var registers = _order.GetDetails(id).Result;
            List<RegisterItemViewModel>model=new List<RegisterItemViewModel>();
            foreach (var item in registers)
            {
                model.Add(new RegisterItemViewModel()
                {
                    Count = item.Count.ToString(),
                    FoodImage = item.Food.FoodImage,
                    FoodCalories = item.Food.FoodCalories,
                    FoodFat = item.Food.FoodFat,
                    FoodCarbohydrate = item.Food.FoodCarbohydrate,
                    FoodProtein = item.Food.FoodProtein,
                    FoodCode = item.Food.FoodCode,
                    FoodTitle = item.Food.FoodTitle,
                    Me = item.Me,
                    Meal = item.Food.Meal.MealTitle,
                    Week = ConvertEnum.ChangeWeek(item.Food.Day)
                });
            }
            InfoUserRegisterViewModel infoUser=new InfoUserRegisterViewModel();
            infoUser.City = userInfo.Address.City.CityName;
            infoUser.Number = userInfo.PhoneNumber;
            infoUser.Name = userInfo.UserFullName;
            infoUser.State = userInfo.Address.City.State.StateName;
            infoUser.AddressText = userInfo.Address.AddressText;
            infoUser.AddressCode = userInfo.Address.AddressCode;
            infoUser.UserAge = userInfo.MedicalInformation.UserAge;
            infoUser.UserWeight = userInfo.MedicalInformation.UserWeight;
            infoUser.UserCalories= userInfo.MedicalInformation.UserCalories;
            infoUser.UserGender = ConvertEnum.ChangeGenderToViewModel(userInfo.MedicalInformation.UserGender);
            infoUser.UserCarbohydrate = userInfo.MedicalInformation.UserCarbohydrate;
            infoUser.UserFat = userInfo.MedicalInformation.UserFat;
            infoUser.SicknessId = userInfo.MedicalInformation.Sickness.SicknessTitle;
            infoUser.UserHeight = userInfo.MedicalInformation.UserHeight;
            infoUser.UserProtein = userInfo.MedicalInformation.UserProtein;
            return Tuple.Create(model, infoUser);
        }

        public void KitchenReady(string order)
        {
            var model = _orderInterface.GetOrderById(order).Result;
            model.Condition = ConditionEnum.Preparation;
            _orderInterface.UpdateOrder(model);
        }

        public void KitchenFinish(string order)
        {
            var model = _orderInterface.GetOrderById(order).Result;
            model.Condition = ConditionEnum.Delivery;
            _orderInterface.UpdateOrder(model);
        } 
        public void Delivery(string order)
        {
            var model = _orderInterface.GetOrderById(order).Result;
            model.Condition = ConditionEnum.Close;
            _orderInterface.UpdateOrder(model);
        }

        public bool DeleteOrder(string order)
        {
            var model = _orderInterface.GetOrderById(order).Result;
            try
            {
                _orderInterface.DeleteOrder(model);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
