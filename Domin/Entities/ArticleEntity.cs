using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
   public class ArticleEntity
    {
        public string ArticleId { set; get; } = Guid.NewGuid().ToString();
        public string ArticleTitle { set; get; }
        public string ArticleImage { set; get; }
        public int VisitCount { set; get; }
        public string ArticleBody { set; get; }
        public string ArticleTags { set; get; }
        public DateTime CreatedTime { set; get; } = DateTime.Now;
        public string TimeStudy { set; get; }
        public string Summary { set; get; }
        public string CategoryId { set; get; }
        public CategoryEntity Category { set; get; }
        public IEnumerable<CommentArticleEntity> Comments { set; get; }
        public ArticleSeoEntity Seo { set; get; }
    }
}
