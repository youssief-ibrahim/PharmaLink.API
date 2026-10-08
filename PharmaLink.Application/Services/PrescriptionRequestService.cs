using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using PharmaLink.Application.Common;
using PharmaLink.Application.DTO_s.PharmaRequests;
using PharmaLink.Application.IServices;
using PharmaLink.Domain.Contracts;
using PharmaLink.Domain.Entities.Pharma_Requests;
using PharmaLink.Domain.Entities.User;

namespace PharmaLink.Application.Services
{
    public class PrescriptionRequestService : IPrescriptionRequestService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;
        public PrescriptionRequestService(IUnitOfWork _unitOfWork, IMapper _mapper, IWebHostEnvironment _webHostEnvironment)
        {
            unitOfWork = _unitOfWork;
            webHostEnvironment = _webHostEnvironment;
            mapper = _mapper;
        }
        public async Task<Result<PrescriptionRequestDto>> CreateRequestAsync(CreatePrescriptionRequestDto createDto, int patientId)
        {
            var patientProfileRepo =await unitOfWork.GetRepository<PatientProfile, int>().GetByIdAsync(patientId);
            if (patientProfileRepo == null)
                 return Error.NotFound($"patientProfile Not Found ", $"patientProfile with this id {patientId} is Not Found");

            var deliveryAddressRepo = await unitOfWork.GetRepository<PatientAddress, int>().GetByIdAsync(createDto.DeliveryAddressId);
            if(deliveryAddressRepo == null)
                return Error.NotFound($"Delivery Address Not Found ", $"Delivery Address with this id {createDto.DeliveryAddressId} is Not Found");
            if (deliveryAddressRepo.PatientProfileId != patientId) 
                return Error.NotFound("Delivery Address Not Found", "This delivery address does not belong to this patient.");
            
            var prescriptionRequest = mapper.Map<PrescriptionRequestEntity>(createDto);

            prescriptionRequest.PatientProfile = patientProfileRepo;
            prescriptionRequest.DeliveryAddress= deliveryAddressRepo;

            prescriptionRequest.ExpiresAt =DateTime.UtcNow.AddHours(24);

            if(createDto.ImageUrl != null)
            {
                var extension = Path.GetExtension(createDto.ImageUrl.FileName);
                if (!ImageSetting.AllowedExtensions.Contains(extension,StringComparer.OrdinalIgnoreCase))
                     return Error.Validation("Invalid File Extension", "Only JPG, JPEG, and PNG files are allowed.");
           

                if (createDto.ImageUrl.Length > ImageSetting.MaxSize) 
                    return Error.Validation("File Too Large", "The maximum allowed file size is 5 MB.");
                

                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images", "Prescriptions");

                if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

                var uiqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(createDto.ImageUrl.FileName)}";
                var filePath = Path.Combine(uploadFolder, uiqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await createDto.ImageUrl!.CopyToAsync(fileStream);
                }
                prescriptionRequest.ImageUrl = $"Images/Prescriptions/{uiqueFileName}";
            }

            await unitOfWork.GetRepository<PrescriptionRequestEntity, int>().AddAsync(prescriptionRequest);
             var res= await unitOfWork.SaveChangeAsync();
            if (res > 0)   return mapper.Map<PrescriptionRequestDto>(prescriptionRequest);
          
            else return Error.Failure("Failed to create prescription request.", "An error occurred while creating the prescription request.");
            
        }
    }
}
