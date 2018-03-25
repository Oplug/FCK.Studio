using AutoMapper;
using FCK.Studio.Core;

namespace FCK.Studio.Web.AutoMapper.Profiles
{
    public class AdminProfile:Profile
    {
        public AdminProfile()
        {
            CreateMap<Admins, Dto.AdminDto>();
        }
    }
}