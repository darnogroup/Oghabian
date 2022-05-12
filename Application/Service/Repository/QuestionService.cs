using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Question;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class QuestionService:IQuestionService
    {
        private readonly IQuestionInterface _question;

        public QuestionService(IQuestionInterface question)
        {
            _question = question;
        }
        public Tuple<List<QuestionViewModel>, int, int> GetQuestions(int page, string search = "")
        {
            int pageSelected = page;
            int count =_question.CountQuestion().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _question.GetQuestions(search, pageSkip).Result;
            List<QuestionViewModel> question = new List<QuestionViewModel>();

            foreach (var item in list)
            {
                question.Add(new QuestionViewModel()
                {
                   QuestionTitle = item.QuestionTitle,
                   QuestionId = item.QuestionId
                });
            }
            return Tuple.Create(question, count, pageSelected);
        }

        public async Task<UpdateQuestionViewModel> GetQuestionById(string id)
        {
            var result = await _question.GetQuestionById(id);
            UpdateQuestionViewModel question=new UpdateQuestionViewModel();
            question.QuestionId = result.QuestionId;
            question.QuestionAnswer = result.QuestionAnswer;
            question.QuestionTitle = result.QuestionTitle;
            return question;
        }

        public bool InsertQuestion(InsertQuestionViewModel model)
        {
            QuestionEntity question=new QuestionEntity();
            question.QuestionTitle = model.QuestionTitle;
            question.QuestionAnswer = model.QuestionAnswer;
            try
            {
                _question.InsertQuestion(question);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateQuestion(UpdateQuestionViewModel model)
        {
            var question = _question.GetQuestionById(model.QuestionId).Result;
            question.QuestionTitle = model.QuestionTitle;
            question.QuestionAnswer = model.QuestionAnswer;
            try
            {
                _question.UpdateQuestion(question);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteQuestion(string id)
        {
            var question = _question.GetQuestionById(id).Result;
            try
            {
                _question.DeleteQuestion(question);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
