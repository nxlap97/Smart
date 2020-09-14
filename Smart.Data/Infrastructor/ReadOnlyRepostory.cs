using Microsoft.EntityFrameworkCore;
using Smart.Core.Domain;
using Smart.Domain.Model;
using System;
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

        [Obsolete]
        public string GetList(string roleId, int pageIndex = 1,int pageSize = int.MaxValue)
        {
            var roleIdParameter = new SqlParameter
            {
                ParameterName = "RoleId",
                Value = roleId,
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

            _context.Database.ExecuteSqlCommand("exec SP_GetRoleGroups @RoleId, @JsonData OUTPUT", roleIdParameter, dataJsonParam);

            return dataJsonParam.Value.ToString();
        }

    }
}
