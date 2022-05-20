using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class ColumnEntity
    {
        public string Id { set; get; } = Guid.NewGuid().ToString();
        public string Columns { set; get; }
        public string RowId { set; get; }
        public RowEntity Row { set; get; }
    }
}
