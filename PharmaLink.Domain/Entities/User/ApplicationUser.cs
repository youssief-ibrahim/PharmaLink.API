using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PharmaLink.Domain.Entities.UserAccess;
using PharmaLink.Domain.Enums.UserRoleEnums;

namespace PharmaLink.Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public UserRole Role { get; set; }

        public  ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public  ICollection<Complaint> Complaints { get; set; } = new HashSet<Complaint>();
        public  ICollection<Complaint> ResolvedComplaints { get; set; } = new HashSet<Complaint>();

        public  PatientProfile? PatientProfile { get; set; }
        public  PharmaOwner? PharmaOwnerProfile { get; set; }
    }
}
