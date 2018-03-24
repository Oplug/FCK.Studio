using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.Dto
{
    public class ArticleWithCategory
    {
        public Articles Article { get; set; }
        public List<Categories> Category { get; set; }
    }
}