using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.Dto
{
    public class ArticleWithCategory
    {
        public ArticleInput Article { get; set; }
        public List<CategoryTree> Category { get; set; }
    }

    public class ArticleDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Categories Category { get; set; }
        public bool IsRecommend { get; set; }
        public bool IsHot { get; set; }
        public bool IsTop { get; set; }
        public string CreationTime { get; set; }
        public string UpdateTime { get; set; }
    }
    public class ArticleInput
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Tags { get; set; }
        public string Intro { get; set; }
        public string LinkUrl { get; set; }
        public string Images { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public bool IsRecommend { get; set; }
        public bool IsHot { get; set; }
        public bool IsTop { get; set; }
        public string CreationTime { get; set; }
        public string UpdateTime { get; set; }
        public string Contents { get; set; }
        public int LimitSignUp { get; set; }
        public int SignUpNums { get; set; }
        public string SignUpEndTime { get; set; }
    }
}