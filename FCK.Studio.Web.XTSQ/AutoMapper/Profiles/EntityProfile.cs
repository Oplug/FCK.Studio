using AutoMapper;
using FCK.Studio.Core;

namespace FCK.Studio.Web.XTSQ.AutoMapper.Profiles
{
    public class EntityProfile: Profile
    {
        public EntityProfile()
        {
            CreateMap<Articles, Dto.ArticleDto>();
            CreateMap<Dto.ArticleDto, Articles>();
            CreateMap<Categories, Dto.CategoryTree>();
            CreateMap<Products, Dto.ProductDto>();
            CreateMap<Products, Dto.DemdInfoDto>();
            CreateMap<Election, Dto.ElectionDto>();
            CreateMap<Comments, Dto.CommentDto>();
            CreateMap<Members, Dto.MemberDto>();
        }
    }
}