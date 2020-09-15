using Microsoft.EntityFrameworkCore;
using Smart.Core.Domain;
using Smart.Domain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Smart.Data.Infrastructor
{
    public class ReadOnlyRepostory :  IReadOnlyRepository
    {
        private readonly SmartDbContext _context;
        public ReadOnlyRepostory(SmartDbContext context)
        {
                _context = context;
        }

        public string GetList(KeyValuePair<string, string> filter,string sp_name)
        {
            var paramIdParameter = new SqlParameter
            {
                ParameterName = filter.Key,
                Value = filter.Value,
                Size = Int32.MaxValue,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };

            var dataJsonParam = new SqlParameter
            {
                ParameterName = "JsonData",
                DbType = System.Data.DbType.String,
                Size = Int32.MaxValue,
                Direction = System.Data.ParameterDirection.Output
            };

            _context.Database.ExecuteSqlCommand($"exec {sp_name} @{filter.Key}, @JsonData OUTPUT", paramIdParameter, dataJsonParam);

            return dataJsonParam.Value.ToString();
        }

        public string GetListPaging(KeyValuePair<string, string> filter,string sp_name, out int totalRow, int pageIndex = 1, int pageSize = int.MaxValue)
        {
            var roleIdParameter = new SqlParameter
            {
                ParameterName = filter.Key,
                Value = filter.Value,
                Size = Int32.MaxValue,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };

            var dataJsonParam = new SqlParameter
            {
                ParameterName = "JsonData",
                DbType = System.Data.DbType.String,
                Size = Int32.MaxValue,
                Direction = System.Data.ParameterDirection.Output
            };

            var totalRowParam = new SqlParameter
            {
                ParameterName = "TotalRow",
                DbType = System.Data.DbType.String,
                Size = Int32.MaxValue,
                Direction = System.Data.ParameterDirection.Output
            };

            _context.Database.ExecuteSqlCommand($"exec {sp_name} @{filter.Key}, @JsonData OUTPUT, @TotalRow OUTPUT", roleIdParameter, dataJsonParam, totalRowParam);

            totalRow = (int)totalRowParam.Value;

            return dataJsonParam.Value.ToString();
        }

    }
}
