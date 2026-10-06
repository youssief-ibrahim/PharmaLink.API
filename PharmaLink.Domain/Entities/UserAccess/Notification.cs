using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Domain.Enums.UserAccessEnums;

namespace PharmaLink.Domain.Entities.UserAccess
{
    public class Notification :BaseEntity<int>
    {
        public NotificationType NotifyType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; }
        public bool IsRead { get; set; }

        public string ApplicationUserId { get; set; }
        public  ApplicationUser ApplicationUser { get; set; }
    }
}
