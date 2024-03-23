using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PharmaLibrary
{
    public class Cls_Seller
    {
        public static bool UpdateStock(string MedCode, int FinalQty)
        {

            using (var ctx = new pharmacyEntities())
            {
                var med = ctx.Med_details.Where(a => a.MedCode == MedCode).SingleOrDefault();
                med.MedStock = FinalQty;
                ctx.Entry(med).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }
        public static int SaveBill(Billing_details billdt)
        {
            using (var ctx = new pharmacyEntities())
            {
                ctx.Billing_details.Add(billdt);
                ctx.SaveChanges();
                return billdt.BillId;
            }
        }
        
    }
}
