using Smart.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Smart.Website.Areas.Admin.Models
{
    public class PermisionViewModel
    {
        public PermisionViewModel()
        {
            ControllerList = new List<ControllerModel>();
            RoleList = new List<SelectionModel>();
            RoleGroups = new List<RoleGroupViewModel>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public List<SelectionModel> RoleList { get; set; }
        public List<ControllerModel> ControllerList { get; set; }

        public List<RoleGroupViewModel> RoleGroups { get; set; }
        
    }

    public class ControllerModel
    {
        public ControllerModel()
        {
            ActionList = new List<ActionModel>();
        }
        public string Name { get; set; }
        public List<ActionModel> ActionList { get; set; }

    }

    public class ActionModel
    {
        public string Name { get; set; }
    }
}
