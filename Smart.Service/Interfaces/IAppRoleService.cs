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
        void InsertRole(AppRole role);
        void InsertRoleGroups(List<RoleGroup> groupRoles);
        void DeleteRoleGroups(string roleId);
        void DeleteCustomerRoles(string roleId);
        List<RoleGroupModel> GetRoleGroups(string roleId);
        void InsertCustomerRoles(List<UserRole> customerRoles);
        List<PermisionCustomerModel> checkAccessPermision(string customerId);
    }
}
