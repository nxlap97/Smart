using Smart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Website.Areas.Admin.Models
{
    public class CustomerRoleViewModel
    {
        public CustomerRoleViewModel()
        {
            Roles = new List<AppRole>();
            UserRoles = new List<UserRole>();
        }
        public string CustomerId { get; set; }
        public List<AppRole> Roles { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }

}
