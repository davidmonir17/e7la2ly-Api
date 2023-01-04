using AutoMapper;
using DataTransferObjects;
using DataTransferObjects.CreationDto;
using DataTransferObjects.UpdateDto;
using Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace e7la2ly_Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDTO>().ForMember(x => x.location, opt => opt.MapFrom(x => string.Join(' ', x.location.zone, ',', x.location.City))).ReverseMap();


            CreateMap<Branch, BranchDTO>().ForMember(x => x.location, opt => opt.MapFrom(x => string.Join(' ', x.location.zone, ',', x.location.City)))
                .ForMember(x => x.brand, opt => opt.MapFrom(x => x.brand.brandName)).ForMember(x => x.opiningTime, opt => opt.MapFrom(x => x.opiningTime.ToString("HH:mm")))
                .ForMember(x => x.closeTime, opt => opt.MapFrom(x => x.closeTime.ToString("HH:mm"))).ReverseMap();


            CreateMap<Employee, EmployeeDTO>().ForMember(x => x.location, opt => opt.MapFrom(x => string.Join(' ', x.location.zone, ',', x.location.City))).ReverseMap();


            CreateMap<BranchCreationDto, Branch>()
          .ForMember(x => x.opiningTime, opt => opt.MapFrom(x => DateTime.ParseExact(x.opiningTime, "HH:mm", null)))
          .ForMember(x => x.closeTime, opt => opt.MapFrom(x => DateTime.ParseExact(x.closeTime, "HH:mm", null))).ReverseMap();


            CreateMap<EmployeeForCreationDto, Employee>().ReverseMap();


            CreateMap<EmployeeUpdateDTO, Employee>().ReverseMap();

        }
    }
}
