﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.Dto
{
    public class TenantDto
    {
        public int Id { get; set; }
        public string TenantName { get; set; }
        public string SecretKey { get; set; }
        public string AppDomain { get; set; }
        public string WXAppId { get; set; }
        public bool IsRoot { get; set; }
        public string CreationTime { get; set; }
    }

    public class TenantSelect
    {
        public int Id { get; set; }
        public string TenantName { get; set; }
        public bool selected { get; set; }
    }
}