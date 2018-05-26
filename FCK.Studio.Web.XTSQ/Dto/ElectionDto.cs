using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.XTSQ.Dto
{
    public class ElectionDto
    {
        public int Id { get; set; }
        public string Voter { get; set; }
        public string CreationTime { get; set; }
        public string EndTime { get; set; }
        public string Intro { get; set; }
        public string Photo { get; set; }
        public int TenantId { get; set; }
        public string Candidate { get; set; }
        public int NumOfVote { get; set; }
        public bool IsOpen { get; set; }
    }
}