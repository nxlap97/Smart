using Smart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Domain.Model
{
    public class PermisionCustomerModel
    {
        public string CustomerId { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public PermisionType Type { get; set; }
    }
}
