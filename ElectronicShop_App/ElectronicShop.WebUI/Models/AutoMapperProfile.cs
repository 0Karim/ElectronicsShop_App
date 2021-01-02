using AutoMapper;
using ElectronicShop.Domain;
using ElectronicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.WebUI.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, SessionUser>()
                    .ForMember(user => user.Id, options => options.MapFrom(user => user.Id))
                    .ForMember(user => user.UserName, options => options.MapFrom(user => user.UserName))
                    .ForMember(user => user.FullNameAr, options => options.MapFrom(user => user.NameAr))
                    .ForMember(user => user.FullNameEn , options => options.MapFrom(user => user.NameEn))
                    .ForMember(user => user.Role, options => options.MapFrom(user => user.Role))
                    .ForMember(user => user.RoleId, options => options.MapFrom(user => user.RoleId));
        }

    }
}
