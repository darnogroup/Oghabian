using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IUserQuestionInterface
    {
        Task<IEnumerable<UserQuestionEntity>> GetQuestions(string search,int skip);
        Task<UserQuestionEntity> GetQuestionById(string id);
        Task<UserAnswerEntity> GetAnswerById(string id);
        Task<IEnumerable<UserAnswerEntity>> GetAnswer(string id);
        void InsertAnswer(UserAnswerEntity model);
        void UpdateQuestion(UserQuestionEntity model);
        void DeleteQuestion(UserQuestionEntity question);
        void DeleteAnswer(UserAnswerEntity question);
        int Count();
    }
}
