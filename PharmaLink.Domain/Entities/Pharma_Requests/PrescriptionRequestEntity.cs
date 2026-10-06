using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Domain.Entities.UserAccess;
using PharmaLink.Domain.Enums.PharmaEnums;

namespace PharmaLink.Domain.Entities.Pharma_Requests
{
    public class PrescriptionRequestEntity : BaseEntity<int>
    {
        public string? ImageUrl { get; set; }
        public string? PatientNotes { get; set; }
        public string? MedicineName { get; set; }
        public PrescriptionStatus Status { get; set; } = PrescriptionStatus.Pending; 
        public DateTime ExpiresAt { get; set; } 

        public  Order? Order { get; set; } 

        public  ICollection<PrescriptionRequestHistory> PrescriptionRequestHistorys { get; set; } = new HashSet<PrescriptionRequestHistory>();

        public  ICollection<Bid> Bids { get; set; } = new HashSet<Bid>(); 

        public int PatientProfileId { get; set; }
        public  PatientProfile PatientProfile { get; set; }

        public int DeliveryAddressId { get; set; }
        public  PatientAddress DeliveryAddress { get; set; }
    }
}
