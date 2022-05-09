using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ISicknessInterface
    {
        Task<IEnumerable<SicknessEntity>> GetSickness(string search, int skip);
        Task<SicknessEntity> GetSicknessById(string id);
        void InsertSickness(SicknessEntity sickness);
        void UpdateSickness(SicknessEntity sickness);
        void DeleteSickness(SicknessEntity sickness);
        int CountSickness();
    }
}
