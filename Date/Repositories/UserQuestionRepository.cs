using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date.Context;
using Domin.Entities;
using Domin.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories
{
    public class UserQuestionRepository:IUserQuestionInterface
    {
        private readonly DataBaseContext _context;

        public UserQuestionRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserQuestionEntity>> GetQuestions(string search, int skip)
        {
            return await _context.UserQuestion.OrderByDescending(o => o.CreateTime)
                .Include(i => i.User)
                .Where(w => w.UserQuestionTitle.ToLower().Contains(search)).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<UserQuestionEntity> GetQuestionById(string id)
        {
            return await _context.UserQuestion.Include(i => i.User)
                .SingleOrDefaultAsync(s => s.UserQuestionId == id);
        }

        public async Task<UserAnswerEntity> GetAnswerById(string id)
        {
            return await _context.UserAnswer.FindAsync(id);
        }

        public async Task<IEnumerable<UserAnswerEntity>> GetAnswer(string id)
        {
            return await _context.UserAnswer.Include(i => i.User)
                .OrderByDescending(o => o.Time)
                .Where(w => w.QuestionId == id).ToListAsync();
        }

        public void InsertAnswer(UserAnswerEntity model)
        {
            _context.UserAnswer.Add(model);Save();
        }

        public void UpdateQuestion(UserQuestionEntity model)
        {
            _context.Update(model);Save();
        }

        public void DeleteQuestion(UserQuestionEntity question)
        {
            _context.UserQuestion.Remove(question);Save();
        }

        public void DeleteAnswer(UserAnswerEntity question)
        {
            _context.UserAnswer.Remove(question);Save();
        }

        public int Count()
        {
            return _context.Question.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
