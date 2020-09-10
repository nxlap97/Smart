using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Smart.Domain.Enums
{
    public enum PermisionEnum
    {
        [Description("Read")]
        Read = 0,
        [Description("Create")]
        Create = 1,
        [Description("Edit")]
        Edit = 2,
        [Description("Delete")]
        Delete = 3,
    }
}
