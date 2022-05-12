using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Sickness;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class SicknessService : ISicknessService
    {
        private readonly ISicknessInterface _sickness;

        public SicknessService(ISicknessInterface sickness)
        {
            _sickness = sickness;
        }
        public Tuple<List<SicknessViewModel>, int, int> GetSickness(int page, string search = "")
        {
            int pageSelected = page;
            int count = _sickness.CountSickness().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _sickness.GetSickness(search, pageSkip).Result;
            List<SicknessViewModel> sickness = new List<SicknessViewModel>();

            foreach (var item in list)
            {
                sickness.Add(new SicknessViewModel()
                {
                    SicknessTitle = item.SicknessTitle,
                    SicknessId = item.SicknessId,
                    SicknessPath = item.SicknessImagePath
                });
            }
            return Tuple.Create(sickness, count, pageSelected);
        }

        public async Task<UpdateSicknessViewModel> GetSicknessById(string id)
        {
            var result = await _sickness.GetSicknessById(id);
            UpdateSicknessViewModel sickness = new UpdateSicknessViewModel();
            sickness.SicknessId = result.SicknessId;
            sickness.SicknessPath = result.SicknessImagePath;
            sickness.SicknessTitle = result.SicknessTitle;
            return sickness;
        }

        public bool InsertSickness(InsertSicknessViewModel model)
        {
            SicknessEntity sickness = new SicknessEntity();
            sickness.SicknessTitle = model.SicknessTitle;
            if (model.SicknessFile != null)
            {
                var check = model.SicknessFile.IsImage();
                if (check)
                {
                    sickness.SicknessImagePath = ImageProcessing.SaveImage(model.SicknessFile);
                }
                else
                {
                    sickness.SicknessImagePath = "notFound.png";
                }
            }
            else
            {
                sickness.SicknessImagePath = "notFound.png";
            }

            try
            {
                _sickness.InsertSickness(sickness);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSickness(UpdateSicknessViewModel model)
        {
            var sickness = _sickness.GetSicknessById(model.SicknessId).Result;
            sickness.SicknessTitle = model.SicknessTitle;
            if (model.SicknessFile != null)
            {
                var check = model.SicknessFile.IsImage();
                if (check)
                {
                    sickness.SicknessImagePath = ImageProcessing.SaveImage(model.SicknessFile);
                    if (model.SicknessPath != "notFound.png")
                    {
                        ImageProcessing.RemoveImage(model.SicknessPath);
                    }
                }
            }

            try
            {
                _sickness.UpdateSickness(sickness);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSickness(string id)
        {
            var result = _sickness.GetSicknessById(id).Result;
            try
            {
                _sickness.DeleteSickness(result);
                if (result.SicknessImagePath != "notFound.png")
                {
                    ImageProcessing.RemoveImage(result.SicknessImagePath);
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
