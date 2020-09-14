using Smart.Domain.Entity;
using Smart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain

{
    [Table("RoleGroups")]
    public class RoleGroup : ParentEntity<string>
    {
        public string RoleId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public PermisionEnum Type { get; set; }
    }
}
