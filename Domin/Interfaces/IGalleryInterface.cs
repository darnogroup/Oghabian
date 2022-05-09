using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
   public interface IGalleryInterface
    {
        Task<IEnumerable<GalleryEntity>> GetGalleries(string parentId);
        Task<GalleryEntity> GetGalleryById(string id);
        void InsertGallery(GalleryEntity gallery);
        void DeleteGallery(GalleryEntity gallery);

    }
}
