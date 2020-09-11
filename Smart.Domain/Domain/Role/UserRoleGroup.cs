using Smart.Core.Domain.Enums;
using Smart.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain
{
    [Table("UserRoleGroups")]
    public class UserRoleGroup : ParentEntity<string>
    {
        public string CustomerId { get; set; } 
        public string GroupRoleId { get; set; } 
    }
}
