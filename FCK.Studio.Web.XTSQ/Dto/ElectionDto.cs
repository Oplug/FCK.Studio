using FCK.Studio.Core;
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
        public int ElectionHdId { get; set; }
        public ElectionHead ElectionHd { get; set; }
    }
    public class ElectionHdDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreationTime { get; set; }
        public string EndTime { get; set; }
        public int CandiNum { get; set; }
        public int VoteNum { get; set; }
        public string Intro { get; set; }
        public int TenantId { get; set; }
        public bool IsOpen { get; set; }
    }
}