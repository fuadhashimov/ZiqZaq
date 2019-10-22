using AutoMapper;
using ZiqZaq.Shared.Models.Entities;
using ZiqZaq.Shared.Models.RequestInputModels;
using ZiqZaq.Shared.Models.RequestOutputModels;

namespace ZiqZaq.Web.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mapping
            CreateMap<ApplicationUser, UserGetOutputModel>();
            CreateMap<ApplicationUser, UserRegisterOutputModel>();
            CreateMap<ApplicationUser, UserLoginOutputModel>();
            CreateMap<ApplicationUser, UserGetByPhoneNumberOutputModel>();

            CreateMap<UserRegisterInputModel, ApplicationUser>();
            CreateMap<UserUpdateInputModel, ApplicationUser>();


            // Vendor Mapping
            CreateMap<Vendor, VendorLoginOutputModel>();
            CreateMap<Vendor, VendorGetOutputModel>();

            CreateMap<VendorCreateInputModel, ApplicationUser>();
            CreateMap<VendorCreateInputModel, Vendor>();
            CreateMap<VendorUpdateInputModel, Vendor>()
                .ForPath(p => p.ApplicationUser.PhoneNumber, m => m.MapFrom(t => t.PhoneNumber));
        }
    }
}
