using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LinkStart.Core.Dtos;
using LinkStart.Core.Models;
using LinkStart.Core.ViewModels;

namespace LinkStart.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<PostDto, Post>();

            CreateMap<Post, PostDto>();
        }

    }
}