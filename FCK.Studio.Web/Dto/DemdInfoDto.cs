using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.Dto
{
    public class DemdInfoDto
    {
        public long Id { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public string Contents { get; set; }
        public string CreationTime { get; set; }
        public string Intro { get; set; }
        public string Keywords { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public string Contactor { get; set; }
        public string Phone { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public string Email { get; set; }
        public int Hits { get; set; }
        public bool IsChecked { get; set; }
        public int CreatorUserId { get; set; }
        public Members Members { get; set; }
    }
}