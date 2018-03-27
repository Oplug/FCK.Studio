using AutoMapper;
using FCK.Studio.Core;

namespace FCK.Studio.Web.AutoMapper.Profiles
{
    public class TenantProfile: Profile
    {
        public TenantProfile()
        {
            CreateMap<Tenants, Dto.TenantDto>();
        }
    }
}