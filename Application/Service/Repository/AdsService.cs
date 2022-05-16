using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Ads;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class AdsService : IAdsService
    {
        private readonly IAdsInterface _ads;

        public AdsService(IAdsInterface ads)
        {
            _ads = ads;
        }
        public async Task<AdsViewModel> GetAdsViewModel()
        {
            AdsViewModel ads = new AdsViewModel();
            var result = await _ads.GetAds();
            if (result != null)
            {
                ads.ImageOneAlt = result.ImageOneAlt;
                ads.ImageOneLink = result.ImageOneLink;
                ads.ImageTwoAlt = result.ImageTwoAlt;
                ads.ImageTwoLink = result.ImageTwoLink;
                ads.ImageSidebarAlt = result.ImageSidebarAlt;
                ads.ImageSidebarLink = result.ImageSidebarLink;
                ads.ImageTwo = result.ImageTwo;
                ads.ImageOne = result.ImageOne;
                ads.ImageSidebar = result.ImageSidebar;
            }
            else
            {
                ads.ImageOneAlt = "";
                ads.ImageOneLink = "";
                ads.ImageTwoAlt = "";
                ads.ImageTwoLink = "";
                ads.ImageSidebarAlt = "";
                ads.ImageSidebarLink = "";
                ads.ImageTwo = "notFound.png";
                ads.ImageOne = "notFound.png";
                ads.ImageSidebar = "notFound.png";
            }

            return ads;
        }

        public void ChangeAds(AdsViewModel model)
        {
            var result = _ads.GetAds().Result;

            if (result != null)
            {
                result.ImageOneAlt = model.ImageOneAlt;
                result.ImageOneLink = model.ImageOneLink;
                result.ImageTwoAlt = model.ImageTwoAlt;
                result.ImageTwoLink = model.ImageTwoLink;
                result.ImageSidebarAlt = model.ImageSidebarAlt;
                result.ImageSidebarLink = model.ImageSidebarLink;

                if (model.ImageOneFile != null)
                {
                    var check = model.ImageOneFile.IsImage();
                    if (check)
                    {
                        if (result.ImageOne != "notFound.png")
                        {
                            ImageProcessing.RemoveImage(result.ImageOne);
                        }
                        result.ImageOne = ImageProcessing.SaveImage(model.ImageOneFile);
                    }
                }
                if (model.ImageTwoFile != null)
                {
                    var check = model.ImageTwoFile.IsImage();
                    if (check)
                    {
                        if (result.ImageTwo != "notFound.png")
                        {
                            ImageProcessing.RemoveImage(result.ImageTwo);
                        }
                        result.ImageTwo = ImageProcessing.SaveImage(model.ImageTwoFile);
                    }
                }
                if (model.ImageSidebarFile != null)
                {
                    var check = model.ImageSidebarFile.IsImage();
                    if (check)
                    {
                        if (result.ImageSidebar != "notFound.png")
                        {
                            ImageProcessing.RemoveImage(result.ImageSidebar);
                        }
                        result.ImageSidebar = ImageProcessing.SaveImage(model.ImageSidebarFile);
                    }
                }
                _ads.Update(result);
            }
            else
            {
                AdsEntity ads = new AdsEntity();


                if (!String.IsNullOrEmpty(model.ImageOneAlt))
                {
                    ads.ImageOneAlt = model.ImageOneAlt;
                }
                else
                {
                    ads.ImageOneAlt = "#";
                }
                if (!String.IsNullOrEmpty(model.ImageOneLink))
                {
                    ads.ImageOneLink = model.ImageOneLink;
                }
                else
                {
                    ads.ImageOneLink = "#";
                }

                if (!String.IsNullOrEmpty(model.ImageTwoAlt))
                {
                    ads.ImageTwoAlt = model.ImageTwoAlt;
                }
                else
                {
                    ads.ImageTwoAlt = "#";
                }
                if (!String.IsNullOrEmpty(model.ImageTwoLink))
                {
                    ads.ImageTwoLink = model.ImageTwoLink;
                }
                else
                {
                    ads.ImageTwoLink = "#";
                }






                if (!String.IsNullOrEmpty(model.ImageSidebarAlt))
                {
                    ads.ImageSidebarAlt = model.ImageSidebarAlt;
                }
                else
                {
                    ads.ImageSidebarAlt = "#";
                }
                if (!String.IsNullOrEmpty(model.ImageSidebarLink))
                {
                    ads.ImageSidebarLink = model.ImageSidebarLink;
                }
                else
                {
                    ads.ImageSidebarLink = "#";
                }


                if (model.ImageOneFile != null)
                {
                    var check = model.ImageOneFile.IsImage();
                    if (check)
                    {

                        ads.ImageOne = ImageProcessing.SaveImage(model.ImageOneFile);
                    }
                }
                else
                {
                    ads.ImageOne = "notFound.png";
                }
                if (model.ImageTwoFile != null)
                {
                    var check = model.ImageTwoFile.IsImage();
                    if (check)
                    {

                        ads.ImageTwo = ImageProcessing.SaveImage(model.ImageTwoFile);
                    }
                }
                else
                {
                    ads.ImageTwo = "notFound.png";
                }
                if (model.ImageSidebarFile != null)
                {
                    var check = model.ImageSidebarFile.IsImage();
                    if (check)
                    {

                        ads.ImageSidebar = ImageProcessing.SaveImage(model.ImageSidebarFile);
                    }
                }
                else
                {
                    ads.ImageSidebar = "notFound.png";
                }
                _ads.Insert(ads);
            }

        }
    }
}
