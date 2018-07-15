using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCK.Studio.Core;

namespace FCK.Studio.Tools.AutoMapper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Members, Dto.MemberOutDto>();
            CreateMap<Houses, Dto.HouseDto>();
        }
    }
}
