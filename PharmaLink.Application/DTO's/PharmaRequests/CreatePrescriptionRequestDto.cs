using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PharmaLink.Domain.Entities.Pharma_Requests;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Domain.Entities.UserAccess;
using PharmaLink.Domain.Enums.PharmaEnums;

namespace PharmaLink.Application.DTO_s.PharmaRequests
{
    public class CreatePrescriptionRequestDto
    {
        
        public IFormFile? ImageUrl { get; set; }

        [MaxLength(500, ErrorMessage = "Patient notes cannot exceed 500 characters")]
        public string? PatientNotes { get; set; }
        [MaxLength(200, ErrorMessage = "Medicine name cannot exceed 200 characters")]
        public string? MedicineName { get; set; }

        [Required(ErrorMessage = "Delivery address is required.")]
        public int DeliveryAddressId { get; set; }
    }
}
