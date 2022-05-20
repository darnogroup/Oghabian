using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class UserQuestionEntity
    {
        public string UserQuestionId { set; get; } = Guid.NewGuid().ToString();
        public string UserQuestionTitle { set; get; }
        public string UserQuestionBody { set; get; }
        public DateTime CreateTime { set; get; }
        public string UserId { set; get; }
        public bool Accept { set; get; }
        public UserEntity User { set; get; }
        public IEnumerable<UserAnswerEntity>Answers { set; get; }
    }
}
