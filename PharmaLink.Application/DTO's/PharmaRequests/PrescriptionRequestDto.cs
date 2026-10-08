using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Entities.Pharma_Requests;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Domain.Entities.UserAccess;
using PharmaLink.Domain.Enums.PharmaEnums;

namespace PharmaLink.Application.DTO_s.PharmaRequests
{
    public class PrescriptionRequestDto
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? PatientNotes { get; set; }
        public string? MedicineName { get; set; }
        public string Status { get; set; }  //
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BidsCount { get; set; } // 

        public string DeliveryArea { get; set; } //
 
    }
}
