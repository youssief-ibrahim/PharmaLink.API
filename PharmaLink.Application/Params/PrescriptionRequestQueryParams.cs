using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Enums.PharmaEnums;

namespace PharmaLink.Application.Params
{
    public class PrescriptionRequestQueryParams :BaseQueryParam
    {
        public PrescriptionStatus? Status { get; set; }

        public int? PatientId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        // Specifically for Pharmacy to filter by distance (Defaults to 5km if not provided)
        public double? RadiusInKm { get; set; } = 5.0;
    }
}
