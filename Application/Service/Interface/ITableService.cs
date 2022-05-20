using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Role;
using Application.ViewModel.Table;

namespace Application.Service.Interface
{
    public interface ITableService
    {
        Tuple<List<TableViewModel>, int, int> GetTables(int page = 1, string search = "");
        Task<UpdateColumnViewModel> UpdateColumnById(string id);
        Task<UpdateTableViewModel> UpdateRowViewModel(string id);
        void InsertRow(InsertTableViewModel table);
        void UpdateRow(UpdateTableViewModel table);
        void DeleteRow(string id);
        void InsertColumn(InsertColumnViewModel column);
        void UpdateColumn(UpdateColumnViewModel column);
        void DeleteColumn(string id);
       
        Task<List<ColumnViewModel>> GetColumns(string id);
    }
}
