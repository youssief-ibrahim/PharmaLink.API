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
    public class PatientAddress : BaseEntity<int>
    {
        public string AddressLine { get; set; }

        public string City { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public bool IsDefault { get; set; }

        public int PatientProfileId { get; set; }
        public  PatientProfile PatientProfile { get; set; }

        public ICollection<PrescriptionRequestEntity> PrescriptionRequests { get; set; } = new HashSet<PrescriptionRequestEntity>();
    }
}
