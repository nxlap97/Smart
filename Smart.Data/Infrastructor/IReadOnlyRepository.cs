using Smart.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Data.Infrastructor
{
    public interface IReadOnlyRepository
    {
        string GetListNoneFilter(string sp_name);
        string GetList(KeyValuePair<string, string> filter, string sp_name);
        string GetListPaging(KeyValuePair<string, string> filter, string sp_name, out int totalRow, int pageIndex = 1, int pageSize = int.MaxValue);
    }
}
