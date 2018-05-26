using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.XTSQ.AutoMapper
{
    public class Configuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Profiles.EntityProfile>();
            });
        }
    }
}