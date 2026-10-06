using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Entities.Pharma_Requests;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Domain.Enums.UserAccessEnums;

namespace PharmaLink.Domain.Entities.UserAccess
{
    public class Order :BaseEntity<int>
    {
        public decimal Amount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string? CancelReason { get; set; }
        //public PaymentMethodType PaymentMethod { get; set; }
        //public PaymentStatus PaymentStatus { get; set; }
        public DateTime? CancelledAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public int PatientAddressId { get; set; }
        public  PatientAddress PatientAddress { get; set; }

        public int BidId { get; set; }
        public  Bid Bid { get; set; }

        public int PatientProfileId { get; set; }
        public  PatientProfile PatientProfile { get; set; }

        public int PharmacyId { get; set; }
        public  Pharmacy Pharmacy { get; set; }

        public int PrescriptionRequestId { get; set; }
        public  PrescriptionRequestEntity PrescriptionRequest { get; set; }

        // 19 - Order (1) To (Many) Payment (Pay)
        //public  ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
        public  ICollection<Complaint> Complaints { get; set; } = new HashSet<Complaint>();

        public  PharmacyRating? PharmacyRating { get; set; }
    }
}
