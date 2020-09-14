using Smart.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Data.Infrastructor
{
    public interface IReadOnlyRepository
    {
        string GetList(string roleId,int pageIndex = 1, int pageSize = int.MaxValue);
    }
}
