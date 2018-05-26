using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCK.Studio.Web.Dto
{
    public class ProductDto
    {
        public long Id { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public string Contents { get; set; }
        public string CreationTime { get; set; }
        public string UpdateTime { get; set; }
        public string Intro { get; set; }
        public string Keywords { get; set; }
        public string Tags { get; set; }
        public int TenantId { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Pictures { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int CreatorUserId { get; set; }
        public Members Members { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Community { get; set; }
        public string Apartment { get; set; }
        public string Address { get; set; }
        public string Contactor { get; set; }
        public string Phone { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public string Email { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}