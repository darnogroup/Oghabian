using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Food;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class GalleryService:IGalleryService
    {
        private readonly IGalleryInterface _gallery;

        public GalleryService(IGalleryInterface gallery)
        {
            _gallery = gallery;
        }
        public async Task<List<ImageViewModel>> GetImages(string food)
        {
            var result = await _gallery.GetGalleries(food);
            List<ImageViewModel>images=new List<ImageViewModel>();
            foreach (var item in result)
            {
                images.Add(new ImageViewModel()
                {
                    ImagePath = item.ImagePath,
                    ImageId = item.ImageId,
                    ImageName = item.ImagePath
                });
            }

            return images;
        }

        public bool InsertImage(InsertImageViewModel model)
        {
            GalleryEntity image=new GalleryEntity();
            image.FoodId = model.FoodId;
            if (model.Image != null)
            {
                var check = model.Image.IsImage();
                if (check)
                {
                    image.ImagePath = ImageProcessing.SaveImage(model.Image);
                }
                else
                {
                    image.ImagePath = "notFound.png";
                }
            }
            else
            {
                image.ImagePath = "notFound.png";
            }

            try
            {
                _gallery.InsertGallery(image);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteImage(string id)
        {
            var image = _gallery.GetGalleryById(id).Result;
            try
            {
                _gallery.DeleteGallery(image);
                if (image.ImagePath != "notFound.png")
                {
                    ImageProcessing.RemoveImage(image.ImagePath);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
