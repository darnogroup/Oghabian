using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class QuestionEntity
    {
        public string QuestionId { set; get; } = Guid.NewGuid().ToString();
        public string QuestionTitle { set; get; }
        public string QuestionAnswer { set; get; }
    }
}
