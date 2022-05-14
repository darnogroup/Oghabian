using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class SliderEntity
    {
        public string SliderId { set; get; } = Guid.NewGuid().ToString();
        public string SliderImagePath { set; get; }
        public string SliderAlt { set; get; }
    }
}
