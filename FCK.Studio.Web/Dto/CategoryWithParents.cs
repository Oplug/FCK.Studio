using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.Dto
{
    public class CategoryWithParents
    {
        public Categories Category { get; set; }
        public List<Categories> ParentLists { get; set; }
    }

    public class CategorySelect
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool selected { get; set; }
    }
}