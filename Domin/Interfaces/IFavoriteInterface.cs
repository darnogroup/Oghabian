using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IFavoriteInterface
    {
        Task<IEnumerable<FavoriteEntity>> GetFavorites(string userId, int skip);
        Task<FavoriteEntity> GetFavoriteById(string id);
        void InsertFavorite(FavoriteEntity favorite);
        void UpdateFavorite(FavoriteEntity favorite);
        void DeleteFavorite(FavoriteEntity favorite);
        int CountFavorite();

    }
}
