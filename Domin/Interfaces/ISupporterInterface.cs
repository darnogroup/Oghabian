using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ISupporterInterface
    {
        Task<IEnumerable<SupporterEntity>> GetSupporters(string search, int skip);
        Task<SupporterEntity> GetSupporterById(string id);
        void InsertSupporter(SupporterEntity supporter);
        void UpdateSupporter(SupporterEntity supporter);
        void DeleteSupporter(SupporterEntity supporter);
        int CountSupporter();
    }
}
