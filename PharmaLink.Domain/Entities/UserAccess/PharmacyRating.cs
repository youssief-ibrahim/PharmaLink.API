using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Entities.Pharma_Requests;
using PharmaLink.Domain.Entities.User;

namespace PharmaLink.Domain.Entities.UserAccess
{
    public class PharmacyRating : BaseEntity<int>
    {
        public int RatingValue { get; set; }
        public string? Comment { get; set; }

        public int PharmacyId { get; set; }
        public  Pharmacy Pharmacy { get; set; }

        public int OrderId { get; set; }
        public  Order Order { get; set; }

        public int PatientProfileId { get; set; }
        public  PatientProfile PatientProfile { get; set; }
    }
}
