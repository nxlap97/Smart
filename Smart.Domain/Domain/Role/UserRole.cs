using Smart.Core.Domain.Enums;
using Smart.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain
{
    [Table("UserRoles")]
    public class UserRole : ParentEntity<string>
    {
        public string CustomerId { get; set; } 
        public string RoleId { get; set; } 
    }
}
