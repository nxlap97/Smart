using Smart.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Data.Infrastructor
{
    public interface IReadOnlyRepository
    {
        string GetList(KeyValuePair<string, string> filter, string sp_name);
    }
}
