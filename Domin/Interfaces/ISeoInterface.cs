using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ISeoInterface
    {
        Task<SeoEntity> GetSeo();
        void Update(SeoEntity model);
        void Insert(SeoEntity model);
        void Save();
    }
}
