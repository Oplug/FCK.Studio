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
        public virtual string CategoryIndex { get; set; }
        public virtual string Layout { get; set; }
        public virtual int ParentId { get; set; }
        public virtual int Level { get; set; }
        public string PrevStr { get; set; }
    }
}