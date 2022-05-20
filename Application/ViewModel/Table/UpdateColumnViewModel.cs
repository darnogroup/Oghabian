using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Table
{
    public class UpdateColumnViewModel
    {
        public int Count { set; get; }
        public string[] Columns { set; get; }
        public string RowId { set; get; }
        public string Id { set; get; }
    }
}
