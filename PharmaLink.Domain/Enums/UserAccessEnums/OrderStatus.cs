using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaLink.Domain.Enums.UserAccessEnums
{
    public enum OrderStatus
    {
        Pending = 1,
        Accepted,
        InTransit,
        Preparing,
        Completed,
        Cancelled,
        Delivered,
        Returned
    }
}
