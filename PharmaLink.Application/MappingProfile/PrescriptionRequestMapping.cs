using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PharmaLink.Application.DTO_s.PharmaRequests;
using PharmaLink.Domain.Entities.Pharma_Requests;

namespace PharmaLink.Application.MappingProfile
{
    public class PrescriptionRequestMapping : Profile
    {
        public PrescriptionRequestMapping()
        {
            // 1 - Mapping From Creation Dto to Entity (Input)

            CreateMap<CreatePrescriptionRequestDto, PrescriptionRequestEntity>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());

            CreateMap<PrescriptionRequestEntity, PrescriptionRequestDto>()
              .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<PictureURLResolver<PrescriptionRequestEntity,PrescriptionRequestDto>,string>(src=>src.ImageUrl!))
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
              .ForMember(dest => dest.BidsCount, opt => opt.MapFrom(src => src.Bids != null ? src.Bids.Count : 0))
              .ForMember(dest => dest.DeliveryArea, opt => opt.MapFrom(src =>
               src.DeliveryAddress != null ? $"{src.DeliveryAddress.City} - {src.DeliveryAddress.AddressLine}" : "UnKnown"));
        }
    }
}
