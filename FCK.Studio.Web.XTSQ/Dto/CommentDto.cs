using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.XTSQ.Dto
{
    public class CommentDto
    {
        public string Contents { get; set; }
        public string CreationTime { get; set; }
        public virtual Members Member { get; set; }
        public bool IsTop { get; set; }
        public bool IsRecommend { get; set; }
    }
}