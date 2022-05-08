using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class CommentArticleEntity
    {
        public string CommentId { set; get; } = Guid.NewGuid().ToString();
        public string CommentBody { set; get; }
        public DateTime CreateTime { set; get; }=DateTime.Now;
        public string ArticleId { set; get; }
        public ArticleEntity Article { set; get; }
    }
}
