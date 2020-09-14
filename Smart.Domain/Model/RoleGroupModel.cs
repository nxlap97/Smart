using Smart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Domain.Model
{
    public class RoleGroupModel
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public PermisionEnum Type { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Published { get; set; }
    }
}
