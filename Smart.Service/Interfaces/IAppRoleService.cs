using Smart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Service.Interfaces
{
    public interface IAppRoleService
    {
        List<AppRole> GetRoles();
    }
}
