using Smart.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain

{
    [Table("GroupRoles")]
    public class GroupRole : ParentEntity<string>
    {
        public string RoleId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
