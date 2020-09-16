﻿using Newtonsoft.Json;
using Smart.Core.Domain;
using Smart.Data.Infrastructor;
using Smart.Domain.Model;
using Smart.Service.Interfaces;
using Smart.Utility.StringHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Service.EF
{
    public class AppRoleService : IAppRoleService
    {
        private readonly IRepository<AppRole, string> _appRoleRepository;
        private readonly IRepository<RoleGroup, string> _roleGroupRepository;
        private readonly IReadOnlyRepository _readOnlyRepository;
        public AppRoleService(IRepository<AppRole, string> appRoleRepository, 
            IRepository<RoleGroup, string> roleGroupRepository,
            IReadOnlyRepository readOnlyRepository)
        {
            _appRoleRepository = appRoleRepository;
            _roleGroupRepository = roleGroupRepository;
            _readOnlyRepository = readOnlyRepository;
        }
        public List<AppRole> GetRoles()
        {
            return _appRoleRepository.FindAll().ToList();
        }

        public List<UserRole> GetUserRoles(string customerId)
        {
            var filter = new KeyValuePair<string, string>("CustomerId", customerId);
            var json = _readOnlyRepository.GetList(filter, StoreProduceHelper.SP_GetUserRoles);
            var model = JsonConvert.DeserializeObject<List<UserRole>>(json);
            return model;
        }

        public void insertRole(AppRole role)
        {
            _appRoleRepository.Add(role);
        }

        public void insertRoleGroups(List<RoleGroup> groupRoles)
        {
            _roleGroupRepository.AddRang(groupRoles);
        }

        public List<RoleGroupModel> GetRoleGroups(string roleId)
        {
            var filter = new KeyValuePair<string, string>("RoleId", roleId);
            var json = _readOnlyRepository.GetList(filter, StoreProduceHelper.SP_GetRoleGroups);
            var model  = JsonConvert.DeserializeObject<List<RoleGroupModel>>(json);
            return model;
        }

        public List<RoleGroup> GetRoleGroupSimple(string roleId)
        {
            var model = _roleGroupRepository.FindAll(x => x.RoleId == roleId).ToList();
            return model;
        }

        public void deleteRoleGroups(string roleId)
        {
            var roleGroups = GetRoleGroupSimple(roleId);
            _roleGroupRepository.RemoveMultiple(roleGroups);
        }
    }
}
