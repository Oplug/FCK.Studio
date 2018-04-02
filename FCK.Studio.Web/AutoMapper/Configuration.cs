using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.AutoMapper
{
    public class Configuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Profiles.ArticleProfile>();
                cfg.AddProfile<Profiles.TenantProfile>();
                cfg.AddProfile<Profiles.AdminProfile>();
                cfg.AddProfile<Profiles.SignUpBespeakProfile>();
            });
        }
    }
}