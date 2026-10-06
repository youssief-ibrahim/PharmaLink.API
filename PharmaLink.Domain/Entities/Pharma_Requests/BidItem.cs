using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;

namespace PharmaLink.Domain.Entities.Pharma_Requests
{
    public class BidItem : BaseEntity<int>
    {
        public string ItemName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; } = 1;
        public bool IsAlternative { get; set; } = false;
        public string? AlternativeNote { get; set; }
        public decimal LineTotal { get; set; }

        public int BidId { get; set; }
        public Bid Bid { get; set; }
    }
}
