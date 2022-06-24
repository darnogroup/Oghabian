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
    public class TableRepository:ITableInterface
    {
        private readonly DataBaseContext _context;

        public TableRepository(DataBaseContext context)
        {
            _context = context;
        }

    

        public async Task<List<RowEntity>> GetRows(string search, int skip)
        {
            return await _context.Row.Where(w=>w.TableName.ToLower().Contains(search)).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<RowEntity> GetRowById(string id)
        {
            return await _context.Row.FindAsync(id);
        }

        public async Task<List<ColumnEntity>> GetColumns(string id)
        {
            return await _context.Column.Where(w => w.RowId == id).ToListAsync();
        }

        public async Task<ColumnEntity> GetColumnById(string id)
        {
            return await _context.Column.FindAsync(id);
        }

        public async Task<ColumnEntity> GetColumnByRowId(string rowId)
        {
            return await _context.Column.SingleOrDefaultAsync(s => s.RowId == rowId);
        }

        public void InsertRow(RowEntity row)
        {
            _context.Row.Add(row);Save();
        }

        public void UpdateRow(RowEntity row)
        {
            _context.Update(row);Save();
        }

        public void InsertColumn(ColumnEntity column)
        {
            _context.Column.Add(column);Save();
        }

        public void UpdateColumn(ColumnEntity column)
        {
            _context.Update(column); Save();
        }

        public void DeleteRow(RowEntity row)
        {
            _context.Row.Remove(row);Save();
        }

        public void DeleteColumn(ColumnEntity column)
        {
            _context.Column.Remove(column);Save();
        }

        public int CountTable()
        {
            return _context.Row.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
