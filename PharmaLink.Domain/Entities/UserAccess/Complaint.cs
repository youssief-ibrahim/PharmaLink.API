using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Domain.Enums.UserAccessEnums;

namespace PharmaLink.Domain.Entities.UserAccess
{
    public class Complaint : BaseEntity<int>
    {
        public ComplaintStatus Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? AdminNotes { get; set; }
        public DateTime? ResolvedAt { get; set; }

        public int? OrderId { get; set; }
        public  Order? Order { get; set; }

        public string SubmittedById { get; set; }
        //[InverseProperty(nameof(ApplicationUser.Complaints))]
        public  ApplicationUser SubmittedBy { get; set; }

        public string? ResolvedById { get; set; }
        //[InverseProperty(nameof(ApplicationUser.ResolvedComplaints))]
        public  ApplicationUser? ResolvedBy { get; set; }
    }
}
