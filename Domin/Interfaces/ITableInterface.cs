using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ITableInterface
    {
       
        Task<List<RowEntity>> GetRows(string search,int skip);
        Task<RowEntity> GetRowById(string id);
        Task<List<ColumnEntity>> GetColumns(string id);
        Task<ColumnEntity> GetColumnById(string id);
        Task<ColumnEntity> GetColumnByRowId(string rowId);
        void InsertRow(RowEntity row);
        void UpdateRow(RowEntity row);
        void InsertColumn(ColumnEntity column);
        void UpdateColumn(ColumnEntity column);
        void DeleteRow(RowEntity row);
        void DeleteColumn(ColumnEntity column);
        int CountTable();
    }
}
