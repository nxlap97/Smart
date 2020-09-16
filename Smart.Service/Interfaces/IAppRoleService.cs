using Smart.Core.Domain;
using Smart.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Service.Interfaces
{
    public interface IAppRoleService
    {
        List<AppRole> GetRoles();
        List<UserRole> GetUserRoles(string customerId);
        void insertRole(AppRole role);
        void insertRoleGroups(List<RoleGroup> groupRoles);
        void deleteRoleGroups(string roleId);
        List<RoleGroupModel> GetRoleGroups(string roleId);
    }
}
