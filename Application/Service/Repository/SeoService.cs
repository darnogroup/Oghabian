using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Seo;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class SeoService : ISeoService
    {
        private readonly ISeoInterface _seo;

        public SeoService(ISeoInterface seo)
        {
            _seo = seo;
        }
        public async Task<SeoViewModel> GetSeoViewModel()
        {
            var seo = await _seo.GetSeo();
            SeoViewModel model = new SeoViewModel();
            if (seo != null)
            {
                model.GraphDescription = seo.GraphDescription;
                model.GraphSiteName = seo.GraphSiteName;
                model.GraphImagePath = seo.GraphImage;
                model.GraphTitle = seo.GraphTitle;
                model.GraphUrl = seo.GraphUrl;
                model.TwitterDescription = seo.TwitterDescription;
                model.TwitterImagePath = seo.TwitterImage;
                model.TwitterTitle = seo.TwitterTitle;
                model.Header = seo.Header;
                model.Footer = seo.Footer;
            }
            else
            {
                model.GraphDescription = "";
                model.GraphSiteName = "";
                model.GraphImagePath = "notFound.png";
                model.GraphTitle = "";
                model.GraphUrl = "";
                model.TwitterDescription = "";
                model.TwitterImagePath = "notFound.png";
                model.TwitterTitle = "";
                model.Header = "";
                model.Footer = "";
            }
            return model;
        }

        public void ChangeSeo(SeoViewModel model)
        {
            var seo = _seo.GetSeo().Result;
            if (seo == null)
            {
                SeoEntity entity = new SeoEntity();
                entity.Header = model.Header;
                entity.Footer = model.Footer;
                entity.GraphDescription = model.GraphDescription;
                entity.GraphSiteName = model.GraphSiteName;
                entity.GraphTitle = model.GraphTitle;
                entity.GraphUrl = model.GraphUrl;
                entity.TwitterDescription = model.TwitterDescription;
                entity.TwitterTitle = model.TwitterTitle;
                if (model.GraphImage != null)
                {
                    var checkImage = model.GraphImage.IsImage();
                    entity.GraphImage = checkImage ? ImageProcessing.SaveImage(model.GraphImage) : "noImage.jpg";
                }

                if (model.TwitterImage != null)
                {
                    var checkImage = model.TwitterImage.IsImage();
                    entity.TwitterImage = checkImage ? ImageProcessing.SaveImage(model.TwitterImage) : "noImage.jpg";
                }

                _seo.Insert(entity);
            }
            else
            {
                seo.Header = model.Header;
                seo.Footer = model.Footer;
                seo.GraphDescription = model.GraphDescription;
                seo.GraphSiteName = model.GraphSiteName;
                seo.GraphImage = model.GraphImagePath;
                seo.GraphTitle = model.GraphTitle;
                seo.GraphUrl = model.GraphUrl;
                seo.TwitterDescription = model.TwitterDescription;
                seo.TwitterImage = model.TwitterImagePath;
                seo.TwitterTitle = model.TwitterTitle;
                if (model.GraphImage != null)
                {
                    var checkImage = model.GraphImage.IsImage();
                    if (checkImage)
                    {
                        seo.GraphImage = ImageProcessing.SaveImage(model.GraphImage);
                        if (model.GraphImagePath != "noImage.jpg")
                        {
                            ImageProcessing.RemoveImage(model.GraphImagePath);
                        }

                    }
                }

                if (model.TwitterImage != null)
                {
                    var checkImage = model.TwitterImage.IsImage();
                    if (checkImage)
                    {
                        seo.TwitterImage = ImageProcessing.SaveImage(model.TwitterImage);
                        if (model.TwitterImagePath != "noImage.jpg")
                        {
                            ImageProcessing.RemoveImage(model.TwitterImagePath);
                        }

                    }
                }

                _seo.Update(seo);
            }
        }
    }
}
