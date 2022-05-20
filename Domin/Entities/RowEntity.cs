using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class RowEntity
    {
        public string Id { set; get; } = Guid.NewGuid().ToString();
        public string TableName { set; get; }
        public string Description { set; get; }
        public string Rows { set; get; }
        public int Count { set; get; }
        public IEnumerable<ColumnEntity>Columns { set; get; }
    }
}
