using Smart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Website.Areas.Admin.Models
{
    public class RoleGroupViewModel
    {
        public string Id { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public PermisionEnum PermisionEnumId { get; set; }
    }
}
