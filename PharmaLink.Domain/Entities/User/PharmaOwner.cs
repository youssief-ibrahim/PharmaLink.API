using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Entities.Pharma_Requests;
using PharmaLink.Domain.Enums.PharmaEnums;

namespace PharmaLink.Domain.Entities.User
{
    public class PharmaOwner : BaseEntity<int>
    {
        public string? NationalId { get; set; }

        public string? NationalIdFront { get; set; }

        public string? NationalIdBack { get; set; }

        public string? SyndicateCardImage { get; set; }

        public PharmaOwnerStatus Status { get; set; } = PharmaOwnerStatus.Pending;

        public string ApplicationUserId { get; set; }
        public  ApplicationUser ApplicationUser { get; set; }

        public  Pharmacy? Pharmacy { get; set; }
    }
}
