using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.Dto
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Powers { get; set; }
        public string CreationTime { get; set; }
    }
}