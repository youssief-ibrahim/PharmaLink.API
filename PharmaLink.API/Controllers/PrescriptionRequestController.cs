using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaLink.Application.IServices;
using PharmaLink.Application.DTO_s.PharmaRequests;

namespace PharmaLink.API.Controllers
{
    public class PrescriptionRequestController : ApiBaseController
    {
        private readonly IPrescriptionRequestService prescriptionRequestService;
        public PrescriptionRequestController(IPrescriptionRequestService _prescriptionRequestService)
        {
            prescriptionRequestService = _prescriptionRequestService;
        }
        [HttpPost]
        [Authorize(Roles ="Patient")]
        public async Task<ActionResult<PrescriptionRequestDto>> CreateOrder([FromForm] CreatePrescriptionRequestDto orderDto)
        {
            var patientId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var patientRequest = await prescriptionRequestService.CreateRequestAsync(orderDto, patientId);
            return HandleResult(patientRequest);
        }
    }
}
