using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Supporter;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class SupporterService:ISupporterService
    {
        private readonly ISupporterInterface _supporter;

        public SupporterService(ISupporterInterface supporter)
        {
            _supporter = supporter;
        }
        public Tuple<List<SupporterViewModel>, int, int> GetSupporters(int page, string search = "")
        {
            int pageSelected = page;
            int count = _supporter.CountSupporter().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _supporter.GetSupporters(search, pageSkip).Result;
            List<SupporterViewModel> supporter = new List<SupporterViewModel>();

            foreach (var item in list)
            {
                supporter.Add(new SupporterViewModel()
                {
                   SupporterName = item.SupporterName,
                   SupporterNumber = item.SupporterNumber,
                   SupporterImage = item.SupporterImage,
                   SupporterId = item.SupporterId
                });
            }
            return Tuple.Create(supporter, count, pageSelected);
        }

        public async Task<UpdateSupporterViewModel> GetSupporterById(string id)
        {
            var result = await _supporter.GetSupporterById(id);
            UpdateSupporterViewModel supporter=new UpdateSupporterViewModel();
            supporter.SupporterName = result.SupporterName;
            supporter.SupporterNumber = result.SupporterNumber;
            supporter.SupporterActivity = result.SupporterActivity;
            supporter.SupporterMail = result.SupporterMail;
            supporter.SupporterAddress = result.SupporterAddress;
            supporter.SupporterDescription = result.SupporterDescription;
            supporter.SupporterId = result.SupporterId;
            supporter.SupporterImagePath = result.SupporterImage;
            return supporter;
        }

        public bool InsertSupporter(InsertSupporterViewModel model)
        {
           SupporterEntity supporter=new SupporterEntity();
           supporter.SupporterName = model.SupporterName;
           supporter.SupporterNumber = model.SupporterNumber;
           supporter.SupporterActivity = model.SupporterActivity;
           supporter.SupporterMail = model.SupporterMail;
           supporter.SupporterAddress = model.SupporterAddress;
           supporter.SupporterDescription = model.SupporterDescription;
           if (model.SupporterImage != null)
           {
               var check = model.SupporterImage.IsImage();
               if (check)
               {
                   supporter.SupporterImage = ImageProcessing.SaveImage(model.SupporterImage);
               }
               else
               {
                   supporter.SupporterImage = "notFound.png";
               }
           }
           else
           {
               supporter.SupporterImage = "notFound.png";
           }

           try
           {
                _supporter.InsertSupporter(supporter);
                return true;
           }
           catch
           {
               return false;
           }
        }

        public bool UpdateSupporter(UpdateSupporterViewModel model)
        {
            var supporter = _supporter.GetSupporterById(model.SupporterId).Result;
            supporter.SupporterName = model.SupporterName;
            supporter.SupporterNumber = model.SupporterNumber;
            supporter.SupporterActivity = model.SupporterActivity;
            supporter.SupporterMail = model.SupporterMail;
            supporter.SupporterAddress = model.SupporterAddress;
            supporter.SupporterDescription = model.SupporterDescription;
            if (model.SupporterImage != null)
            {
                var check = model.SupporterImage.IsImage();
                if (check)
                {
                    supporter.SupporterImage = ImageProcessing.SaveImage(model.SupporterImage);
                    if (model.SupporterImagePath != "notFound.png")
                    {
                        ImageProcessing.RemoveImage(model.SupporterImagePath);
                    }
                }
            }

            try
            {
                _supporter.UpdateSupporter(supporter);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteSupporter(string id)
        {
            var supporter = _supporter.GetSupporterById(id).Result;
            try
            {
                _supporter.DeleteSupporter(supporter);
                if (supporter.SupporterImage != "notFound.png")
                {
                    ImageProcessing.RemoveImage(supporter.SupporterImage);
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
