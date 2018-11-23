using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.XTSQ.Dto
{
    public class MemberDto
    {
        public string Id { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string TrueName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Community { get; set; }
        public string Apartment { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string QQ { get; set; }        
        public int Points { get; set; }
        public int CreditRate { get; set; }
        public bool Approved { get; set; }
        public string Intro { get; set; }
        public string PoliticalRole { get; set; }
        public string CreationTime { get; set; }
        public bool IsReger { get; set; }
    }
}