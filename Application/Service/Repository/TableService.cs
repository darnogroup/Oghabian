using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Article;
using Application.ViewModel.Role;
using Application.ViewModel.Table;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class TableService:ITableService
    {
        private readonly ITableInterface _table;

        public TableService(ITableInterface table)
        {
            _table = table;
        }
        public Tuple<List<TableViewModel>, int, int> GetTables(int page = 1, string search = "")
        {
            int pageSelected = page;
            int count = _table.CountTable().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list =_table.GetRows(search, pageSkip).Result;
            List<TableViewModel> table = new List<TableViewModel>();

            foreach (var item in list)
            {
                table.Add(new TableViewModel()
                {
                    Count = item.Count,
                    Id = item.Id,
                    Name = item.TableName
                });
            }
            return Tuple.Create(table, count, pageSelected);
        }

        public async Task<UpdateColumnViewModel> UpdateColumnById(string id)
        {
            var result = await _table.GetColumnById(id);
            UpdateColumnViewModel column=new UpdateColumnViewModel();
            column.Id = result.Id;
            column.RowId = result.RowId;
            column.Count = _table.GetRowById(id).Result.Count;
            column.Columns = result.Columns.Split("-");
            return column;
        }

        public async Task<UpdateTableViewModel> UpdateRowViewModel(string id)
        {
            UpdateTableViewModel table=new UpdateTableViewModel();
            var result = await _table.GetRowById(id);
            table.Description = result.Description;
            table.Id = result.Id;
            table.Rows = result.Rows.Split("-");
            table.Name = result.TableName;
            return table;
        }

        public void InsertRow(InsertTableViewModel table)
        {
           RowEntity row=new RowEntity();
           row.Count = table.Rows.Count();
           row.Description = table.Description;
           row.TableName = table.Name;
           row.Rows = string.Join("-", table.Rows);
           _table.InsertRow(row);
        }

        public void UpdateRow(UpdateTableViewModel table)
        {
            var row = _table.GetRowById(table.Id).Result;
            row.Count = table.Rows.Count();
            row.Description = table.Description;
            row.TableName = table.Name;
            row.Rows = string.Join("-", table.Rows);
            _table.UpdateRow(row);
        }

        public void DeleteRow(string id)
        {
            var row = _table.GetRowById(id).Result;
            var list = _table.GetColumns(id).Result;
            foreach (var item in list)
            {
                var model = _table.GetColumnById(item.Id).Result;
                _table.DeleteColumn(model);
            }
            _table.DeleteRow(row);
        }

        public void InsertColumn(InsertColumnViewModel column)
        {
            ColumnEntity model=new ColumnEntity();
            model.RowId = column.RowId;
            model.Columns= string.Join("-", column.Columns);
            _table.InsertColumn(model);
        }

        public void UpdateColumn(UpdateColumnViewModel column)
        {
            var model = _table.GetColumnById(column.Id).Result;
            model.Columns = string.Join("-", column.Columns);
            _table.UpdateColumn(model);
        }

        public void DeleteColumn(string id)
        {
            var model = _table.GetColumnById(id).Result;
            _table.DeleteColumn(model);
        }

        

        public async Task<List<ColumnViewModel>> GetColumns(string id)
        {
            var columns = await _table.GetColumns(id);
            List<ColumnViewModel> column=new List<ColumnViewModel>();
            foreach (var item in columns)
            {
                column.Add(new ColumnViewModel()
                {
                    Column = item.Columns,
                    Id = item.Id
            });
            }

            return column;
        }
    }
}
