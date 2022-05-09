using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IQuestionInterface
    {
        Task<IEnumerable<QuestionEntity>> GetQuestions(string search, int skip);
        Task<QuestionEntity> GetQuestionById(string id);
        void InsertQuestion(QuestionEntity question);
        void UpdateQuestion(QuestionEntity question);
        void DeleteQuestion(QuestionEntity question);
        int CountQuestion();
    }
}
