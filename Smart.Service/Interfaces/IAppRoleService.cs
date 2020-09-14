﻿using Smart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Service.Interfaces
{
    public interface IAppRoleService
    {
        List<AppRole> GetRoles();
        void insertRole(AppRole role);
        void insertRoleGroups(List<GroupRole> groupRoles);
    }
}
