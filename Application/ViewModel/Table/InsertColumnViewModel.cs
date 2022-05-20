using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Table
{
    public class InsertColumnViewModel
    {
        public int Count { set; get; }
        [Required(ErrorMessage = "مقادیر هر سطر الزامی است")]
        public string[] Columns { set; get; }
        public string RowId { set; get; }
        public string[]Rows { set; get; }
    }
}
