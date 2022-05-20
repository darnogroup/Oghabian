using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class UserAnswerEntity
    {
        public string UserAnswerId { set; get; } = Guid.NewGuid().ToString();
        public string UserAnswerBody { set; get; }
        public DateTime Time { set; get; }
        public string UserId { set; get; }
        public UserEntity User { set; get; }
        public string QuestionId { set; get; }
        public UserQuestionEntity Question { set; get; }
    }
}
