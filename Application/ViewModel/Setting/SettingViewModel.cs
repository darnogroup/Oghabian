﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Setting
{
    public class SettingViewModel
    {
        public string TitleSite { set; get; }
        public string LogoPath { set; get; }
        public IFormFile Logo { set; get; }
        public string Instagram { set; get; }
        public string WhatsApp { set; get; }
        public string Linkdin { set; get; }
        public string FaceBook { set; get; }
        public string Number { set; get; }
        public string Mail { set; get; }
        public string Bank { set; get; }
        public string ApiSms { set; get; }
        public string ApiNumber { set; get; }
        public string Address { set; get; }
    }
}