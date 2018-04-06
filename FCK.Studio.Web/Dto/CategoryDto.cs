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
        public List<CategoryTree> ParentLists { get; set; }
    }

    public class CategorySelect
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool selected { get; set; }
    }

    public class CategoryTree
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryIndex { get; set; }
        public string Layout { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }
        public string Icons { get; set; }
        public string LinkUrl { get; set; }
        public string PrevStr { get; set; }
    }
}