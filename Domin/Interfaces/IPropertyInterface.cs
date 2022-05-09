using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IPropertyInterface
    {
        Task<IEnumerable<PropertyEntity>> GetProperties(string parent);
        Task<PropertyEntity> GetPropertyById(string id);
        void InsertProperty(PropertyEntity property);
        void DeleteProperty(PropertyEntity property);
    
    }
}
