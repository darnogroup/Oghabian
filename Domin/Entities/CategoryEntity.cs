using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class CategoryEntity
    {
        public string CategoryId { set; get; } = Guid.NewGuid().ToString();
        public string CategoryTitle { set; get; }
        public IEnumerable<ArticleEntity>Articles { set; get; }
    }
}
