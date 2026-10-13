using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Application.Params;
using PharmaLink.Domain.Entities.Pharma_Requests;

namespace PharmaLink.Application.Specifications.PrescriptionReques
{
    public class PatientRequestCountSpec
    : BaseSpecifications<PrescriptionRequestEntity, int>
    {
        public PatientRequestCountSpec(int patientProfileId, PrescriptionRequestQueryParams queryParams)
            : base(request => request.PatientProfileId == patientProfileId &&

                (!queryParams.Status.HasValue || request.Status == queryParams.Status.Value) &&

                (string.IsNullOrWhiteSpace(queryParams.Search) ||
                 (request.MedicineName != null &&
                  request.MedicineName.Contains(queryParams.Search))) &&

                (!queryParams.FromDate.HasValue || request.CreatedAt >= queryParams.FromDate.Value) &&

                (!queryParams.ToDate.HasValue ||  request.CreatedAt <= queryParams.ToDate.Value))
        {
        }
    }
}
