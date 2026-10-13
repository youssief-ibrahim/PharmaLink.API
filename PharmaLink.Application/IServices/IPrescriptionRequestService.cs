using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PharmaLink.Application.Common;
using PharmaLink.Application.DTO_s.PharmaRequests;
using PharmaLink.Application.Params;

namespace PharmaLink.Application.IServices
{
    public interface IPrescriptionRequestService
    {
        Task<Result<PrescriptionRequestDto>>  CreateRequestAsync(CreatePrescriptionRequestDto createDto, int patientId);
        Task<PaginatedResult<PrescriptionRequestDto>> GetPatientRequestsAsync(int patientId, PrescriptionRequestQueryParams queryParams);
    }
}
