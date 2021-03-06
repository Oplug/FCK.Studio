﻿using AutoMapper;
using FCK.Studio.Core;

namespace FCK.Studio.Web.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Articles, Dto.ArticleDto>();
            CreateMap<Articles, Dto.ArticleInput>();
            CreateMap<Dto.ArticleInput, Articles>();
        }
    }
}