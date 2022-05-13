using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Food;

namespace Application.Service.Interface
{
   public interface IPropertyService
   {
       Task<List<PropertyViewModel>> GetProperties(string food);
        bool InsertProperty(InsertPropertyViewModel model);
        bool DeleteProperty(string id);
    }
}
