using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Article
{
    public class InsertArticleViewModel
    {
        [Required(ErrorMessage = "عنوان مقاله وارد نشده است")]
        public string ArticleTitle { set; get; }

        [Required(ErrorMessage = "تصویر مقاله آپلود  نشده است")]
        public IFormFile ArticleImage { set; get; }

        [Required(ErrorMessage = "متن مقاله وارد نشده است")]
        public string ArticleBody { set; get; }

        [Required(ErrorMessage = "برچسب مقاله وارد نشده است")]
        public string ArticleTags { set; get; }

        [Required(ErrorMessage = "زمان مطالعه مقاله وارد نشده است")]
        public string TimeStudy { set; get; }

        [Required(ErrorMessage = "دسته بندی  مقاله انتخاب  نشده است")]
        public string CategoryId { set; get; }
        [Required(ErrorMessage = "خلاصه  مقاله انتخاب  نشده است")]
        public string Summary { set; get; }

    }
}
