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
    public class QuestionRepository:IQuestionInterface
    {
        private readonly DataBaseContext _context;

        public QuestionRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QuestionEntity>> GetQuestions(string search, int skip)
        {
            return await _context.Question.Where(w => w.QuestionTitle.ToLower().Contains(search))
                .Skip(skip).Take(10).ToListAsync();
        }

        public async Task<QuestionEntity> GetQuestionById(string id)
        {
            return await _context.Question.FindAsync(id);
        }

        public void InsertQuestion(QuestionEntity question)
        {
            _context.Question.Add(question);Save();
        }

        public void UpdateQuestion(QuestionEntity question)
        {
            _context.Update(question);Save();
        }

        public void DeleteQuestion(QuestionEntity question)
        {
            _context.Question.Remove(question);
            Save();
        }

        public int CountQuestion()
        {
            return _context.Question.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
