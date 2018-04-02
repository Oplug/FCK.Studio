using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.Dto
{
    public class SignUpBespeakDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Telphone { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string IDCardNo { get; set; }
        public string Address { get; set; }
        public bool IsMarry { get; set; }
        public string CulturalLevel { get; set; }
        public string PoliticalStatus { get; set; }
        public string ActvTitle { get; set; }
        public long ActvID { get; set; }
        public string Memo { get; set; }
        public string CreationTime { get; set; }
    }
}