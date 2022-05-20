using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Question;
using Application.ViewModel.UserQuestion;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class UserQuestionService:IUserQuestionService
    {
        private readonly IUserQuestionInterface _question;

        public UserQuestionService(IUserQuestionInterface question)
        {
            _question = question;
        }
        public Tuple<List<UserQuestionViewModel>, int, int> GetQuestions(int page, string search = "")
        {
            int pageSelected = page;
            int count = _question.Count().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _question.GetQuestions(search, pageSkip).Result;
            List<UserQuestionViewModel> question = new List<UserQuestionViewModel>();

            foreach (var item in list)
            {
                question.Add(new UserQuestionViewModel()
                {
                  UserAvatar = item.User.UserAvatar,
                  QuestionTitle = item.UserQuestionTitle,
                  QuestionId = item.UserQuestionId,
                  Time = item.CreateTime.SolarYear(),
                  UserName = item.User.UserFullName
                });
            }
            return Tuple.Create(question, count, pageSelected);
        }

        public List<UserQuestionAnswerViewModel>GetAnswerById(string id)
        {
            var answers = _question.GetAnswer(id).Result;
         
            List<UserQuestionAnswerViewModel>userQuestionAnswer=new List<UserQuestionAnswerViewModel>();
            foreach (var item in answers)
            {
                userQuestionAnswer.Add(new UserQuestionAnswerViewModel()
                {
              
                    Answer = item.UserAnswerBody,
                    Id = item.UserAnswerId,
                    Time = item.Time.SolarYear(),
                    UserName = item.User.UserFullName
                });
            }

            return userQuestionAnswer;
        }

        public async Task<UserQuestionDetailViewModel> GetQuestionDetail(string id)
        {
            var question = await _question.GetQuestionById(id);
            UserQuestionDetailViewModel detail = new UserQuestionDetailViewModel();
            detail.Title = question.UserQuestionTitle;
            detail.FullName = question.User.UserFullName;
            detail.Body = question.UserQuestionBody;
            detail.Avatar = question.User.UserAvatar;
            detail.Id = question.UserQuestionId;
            detail.Active = question.Accept;
            return detail;
        }

        public void ActiveQuestion(UserQuestionDetailViewModel model)
        {
            var question = _question.GetQuestionById(model.Id).Result;
            question.Accept = model.Active;
            _question.UpdateQuestion(question);
        }

        public void InsertAnswer(InsertAnswerViewModel model)
        {
            UserAnswerEntity answer=new UserAnswerEntity();
            answer.UserId = model.UserId;
            answer.QuestionId = model.QuestionId;
            answer.Time=DateTime.Now;
            answer.UserAnswerBody = model.AnswerText;
            _question.InsertAnswer(answer);
        }

        public void DeleteUserQuestion(string id)
        {
            var question = _question.GetQuestionById(id).Result;
            var list = _question.GetAnswer(question.UserQuestionId).Result;
            foreach (var answer in list)
            {
                var result = _question.GetAnswerById(answer.UserAnswerId).Result;
                _question.DeleteAnswer(result);
            }
            _question.DeleteQuestion(question);
        }

        public void DeleteUserAnswer(string id)
        {
            var result = _question.GetAnswerById(id).Result;
            _question.DeleteAnswer(result);
        }
    }
}
