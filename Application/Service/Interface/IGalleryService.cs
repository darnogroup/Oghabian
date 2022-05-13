using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Food;

namespace Application.Service.Interface
{
    public interface IGalleryService
    {
        Task<List<ImageViewModel>> GetImages(string food);
        bool InsertImage(InsertImageViewModel model);
        bool DeleteImage(string id);
    }
}
