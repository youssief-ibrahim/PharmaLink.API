using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Entities.Pharma_Requests;
using PharmaLink.Domain.Entities.UserAccess;

namespace PharmaLink.Domain.Entities.User
{
    public class PatientProfile : BaseEntity<int>
    {
        // 15 - PatientProfile (1) To (Many) Orders (Placed)
        public  ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public string ApplicationUserId { get; set; }
        public  ApplicationUser ApplicationUser { get; set; }


        public  ICollection<PatientAddress> PatientAddresses { get; set; } = new HashSet<PatientAddress>();
        public  ICollection<PrescriptionRequestEntity> PrescriptionRequests { get; set; } = new HashSet<PrescriptionRequestEntity>();
        public  ICollection<PharmacyRating> PharmacyRatings { get; set; } = new HashSet<PharmacyRating>();
    }
}
