using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.XTSQ.Dto
{
    public class ArticleDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Author { get; set; }
        public Categories Category { get; set; }
        public string CreationTime { get; set; }
        public string UpdateTime { get; set; }
        public string LinkUrl { get; set; }
        public string Images { get; set; }
        public int Hits { get; set; }
    }
}