using PharmaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystem.Models
{
    public class PMSMed : Med_details
    {
        public virtual IList<Med_details> MedDetails { get; set; }
        public virtual Med_details MedDetail { get; set; }
        public int MedQty { get; set; }
        public DateTime BillDate { get; set; }

        public virtual IList<PMSBillList> BillLists { get; set; }
        public virtual PMSBillList BillList { get; set; }
    }
}