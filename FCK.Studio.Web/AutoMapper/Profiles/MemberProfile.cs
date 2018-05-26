using AutoMapper;
using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.AutoMapper.Profiles
{
    public class MemberProfile: Profile
    {
        public MemberProfile()
        {
            CreateMap<Members, Dto.MemberOutDto>();
        }
    }
}