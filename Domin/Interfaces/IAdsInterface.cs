using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IAdsInterface
    {
        Task<AdsEntity> GetAds();
        void Update(AdsEntity model);
        void Insert(AdsEntity model);
        void Save();
    }
}
