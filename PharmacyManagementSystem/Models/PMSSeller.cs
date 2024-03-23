using PharmaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystem.Models
{
    public class PMSSeller : Seller_details
    {
        public virtual IList<Seller_details> SelDetails { get; set; }
        public virtual Seller_details SelDetail { get; set; }
    }
}