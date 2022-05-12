using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Question;

namespace Application.Service.Interface
{
   public  interface IQuestionService
    {
        Tuple<List<QuestionViewModel>, int, int> GetQuestions(int page, string search = "");
        Task<UpdateQuestionViewModel> GetQuestionById(string id);
        bool InsertQuestion(InsertQuestionViewModel model);
        bool UpdateQuestion(UpdateQuestionViewModel model);
        bool DeleteQuestion(string id);
    }
}
