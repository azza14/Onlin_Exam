using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Entities
{
    public enum PermissionAction
    {
        Add = 1,
        Update = 2,
        Delete = 3,
        View=4
    }
    public enum PermissionItem
    {
        User,
        Product,
        Contact,
        Review,
        Client
    }

}
