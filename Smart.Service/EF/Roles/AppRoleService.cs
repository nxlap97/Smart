using Smart.Core.Domain;
using Smart.Data.Infrastructor;
using Smart.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Service.EF
{
    public class AppRoleService : IAppRoleService
    {
        private readonly IRepository<AppRole, string> _appRoleRepository;
        public AppRoleService(IRepository<AppRole, string> appRoleRepository)
        {
            _appRoleRepository = appRoleRepository;
        }
        public List<AppRole> GetRoles()
        {
            return _appRoleRepository.FindAll().ToList();
        }
    }
}
