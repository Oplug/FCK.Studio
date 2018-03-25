using AutoMapper;
using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.AutoMapper.Profiles
{
    public class ArticleProfile: Profile
    {
        public ArticleProfile()
        {
            CreateMap<Articles, Dto.ArticleDto>();
        }
    }
}