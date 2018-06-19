using AutoMapper;
using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.AutoMapper.Profiles
{
    public class EntityProfile: Profile
    {
        public EntityProfile()
        {
            CreateMap<Election, Dto.ElectionDto>();
            CreateMap<ElectionHead, Dto.ElectionHdDto>();
            CreateMap<Products, Dto.ProductDto>();
            CreateMap<Houses, Dto.HouseDto>();
        }
    }
}