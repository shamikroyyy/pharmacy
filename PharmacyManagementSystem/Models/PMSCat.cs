using PharmaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystem.Models
{
    public class PMSCat : Category_details
    {
        public virtual IList<Category_details> CatDetails { get; set; }

        public virtual Category_details CatDetail { get; set; }
    }
}