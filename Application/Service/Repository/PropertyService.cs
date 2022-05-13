using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.City;
using Application.ViewModel.Food;
using Domin.Entities;
using Domin.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Application.Service.Repository
{
    public class PropertyService:IPropertyService
    {
        private readonly IPropertyInterface _property;

        public PropertyService(IPropertyInterface property)
        {
            _property = property;
        }


        public async Task<List<PropertyViewModel>> GetProperties(string food)
        {
            var result = await _property.GetProperties(food);
            List<PropertyViewModel>properties=new List<PropertyViewModel>();
            foreach (var item in result)
            {
                properties.Add(new PropertyViewModel()
                {
                    PropertyValue = item.PropertyValue,
                    PropertyTitle = item.PropertyTitle,
                    PropertyId = item.PropertyId
                });
            }

            return properties;
        }

        public bool InsertProperty(InsertPropertyViewModel model)
        {
            PropertyEntity property=new PropertyEntity();
            property.PropertyValue = model.PropertyValue;
            property.PropertyTitle = model.PropertyTitle;
            property.FoodId = model.FoodId;
            try
            {
                _property.InsertProperty(property);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProperty(string id)
        {
            var model = _property.GetPropertyById(id).Result;
            try
            {
                _property.DeleteProperty(model);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
