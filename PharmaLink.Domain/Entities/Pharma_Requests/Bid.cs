using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Entities.UserAccess;
using PharmaLink.Domain.Enums.PharmaEnums;

namespace PharmaLink.Domain.Entities.Pharma_Requests
{
    public class Bid : BaseEntity<int>
    {
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; } = 0.00m;
        public decimal DeliveryFee { get; set; } = 0.00m; 
        public decimal PlatformFee { get; set; } = 0.00m;  
        public decimal TotalPrice { get; set; }
        public BidStatus Status { get; set; } = BidStatus.Pending;
        public string? Notes { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public DateTime? RespondedAt { get; set; }
        public int DeliveryTimeInMinutes { get; set; }

        public  ICollection<BidItem> BidItems { get; set; } = new HashSet<BidItem>();

        public int PharmacyId { get; set; }
        public  Pharmacy Pharmacy { get; set; }

        // 14 - Order (1) To (1) Bid (Converted To)
        // nullable because the bid can be created and not converted to order yet
        public  Order? Order { get; set; }
        public int PrescriptionRequestId { get; set; }
        public  PrescriptionRequestEntity PrescriptionRequest { get; set; }
    }
}
