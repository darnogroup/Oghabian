using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Link;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class LinkService : ILinkService
    {
        private readonly ILinkInterface _link;

        public LinkService(ILinkInterface link)
        {
            _link = link;
        }
        public Tuple<List<LinkViewModel>, int, int> GetLinks(int page, string search = "")
        {
            int pageSelected = page;
            int count = _link.CountLink().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _link.GetLinks(search, pageSkip).Result;
            List<LinkViewModel> link = new List<LinkViewModel>();

            foreach (var item in list)
            {
                link.Add(new LinkViewModel()
                {
                    LinkTitle = item.LinkTitle,
                    LinkId = item.LinkId
                });
            }
            return Tuple.Create(link, count, pageSelected);
        }

        public async Task<UpdateLinkViewModel> GetLinkById(string id)
        {
            var model = await _link.GetLinkById(id);
            UpdateLinkViewModel link=new UpdateLinkViewModel()
            {
                LinkTitle = model.LinkTitle,
                Link = model.Link,
                LinkId = model.LinkId
            };
            return link;
        }

        public bool InsertLink(InsertLinkViewModel model)
        {
            LinkEntity link=new LinkEntity()
            {
                Link = model.Link,
                LinkTitle = model.LinkTitle
            };
            try
            {
                _link.InsertLink(link);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateLink(UpdateLinkViewModel model)
        {
            var link = _link.GetLinkById(model.LinkId).Result;
       
            link.LinkTitle = model.LinkTitle;
            link.Link = model.Link;
            try
            {
                _link.UpdateLink(link);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteLink(string id)
        {
            var link = _link.GetLinkById(id).Result;
           
            try
            {
                _link.DeleteLink(link);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
