using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Domain.Enums.PharmaEnums;

namespace PharmaLink.Domain.Entities.Pharma_Requests
{
    public class PrescriptionRequestHistory : BaseEntity<int>
    {
        public string Notes { get; set; }
        public PrescriptionStatus NewStatus { get; set; }
        public PrescriptionStatus? OldStatus { get; set; }
        public DateTime ChangedAt { get; set; }
        public int PrescriptionRequestId { get; set; }
        public  PrescriptionRequestEntity PrescriptionRequest { get; set; }
        public string ChangedById { get; set; }
        public  ApplicationUser ChangedBy { get; set; }
    }
}
