using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.UserQuestion;

namespace Application.Service.Interface
{
    public interface IUserQuestionService
    {
        Tuple<List<UserQuestionViewModel>, int, int> GetQuestions(int page,string search="");
       List<UserQuestionAnswerViewModel> GetAnswerById(string id);
       Task<UserQuestionDetailViewModel> GetQuestionDetail(string id);
       void ActiveQuestion(UserQuestionDetailViewModel model);
       void InsertAnswer(InsertAnswerViewModel model);
       void DeleteUserQuestion(string id);
       void DeleteUserAnswer(string id);
    }
}
