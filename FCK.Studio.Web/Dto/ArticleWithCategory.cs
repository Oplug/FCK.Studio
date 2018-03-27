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

    public class ArticleDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Categories Category { get; set; }
        public string CreationTime { get; set; }
        public string UpdateTime { get; set; }
    }
}