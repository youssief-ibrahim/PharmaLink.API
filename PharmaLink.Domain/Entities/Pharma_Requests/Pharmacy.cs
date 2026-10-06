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
    public class Pharmacy : BaseEntity<int>
    {
        public string PharmacyName { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string? LicenseImageUrl { get; set; }
        public PharmacyStatus Status { get; set; } = PharmacyStatus.Pending;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public TimeOnly? OpenTime { get; set; }
        public TimeOnly? CloseTime { get; set; }
        public bool Is24Hours { get; set; } = false;
        public string? TextAddress { get; set; }
        public string Area { get; set; } = string.Empty;
        public string? ContactPhone { get; set; }
        public decimal AverageRating { get; set; } = 0.00m;
        public int CompleteOrderCount { get; set; } = 0;
        public string? RejectedReasons { get; set; }

        
        public  ICollection<Bid> Bids { get; set; } = new HashSet<Bid>();

        public  ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public int PharmaOwnerId { get; set; }
        public  PharmaOwner PharmaOwner { get; set; }

        public  ICollection<PharmacyRating> PharmacyRatings { get; set; } = new HashSet<PharmacyRating>();
        public  ICollection<PharmaPerformSnapshot> PharmaPerformSnapshots { get; set; } = new HashSet<PharmaPerformSnapshot>();
    }
}
