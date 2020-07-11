using AutoMapper;
using ReviewsAPI.DTO;
using ReviewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().AfterMap((source, dest) =>
            {
                dest.Email = source.Email;
                dest.Id = source.Id;
                dest.Role = source.Role;
            });
            CreateMap<UserRegisterDto, User>().AfterMap((source, dest) =>
            {
                dest.Email = source.Email;
                dest.Role = UserRole.Regular;
                dest.Password = source.Password1;
            });
        }
    }
}
