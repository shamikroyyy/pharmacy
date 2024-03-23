using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PharmacyManagementSystem.Models;
using PharmaLibrary;

namespace PharmacyManagementSystem.Controllers
{
    public class PMSBillsController : Controller
    {
        private PMSDBContext db = new PMSDBContext();

        // GET: Bill

        public ActionResult Index(int? id)
        {
            PMSMed model = new PMSMed();

            if (id == null)
            {
                IList<PMSBillList> PMSBL = new List<PMSBillList>();
                PMSBL = Session["billdata"] as List<PMSBillList>;


                model.MedDetails = Cls_Admin.ViewMedicine();
                if (model.BillList == null)
                {
                    PMSBillList obill = new PMSBillList();
                    obill.ID = 0;
                    obill.Name = "";
                    obill.Price = 0;
                    obill.Qty = 0;
                    obill.Total = 0;
                    if (PMSBL == null)
                    {
                        model.BillList = obill;
                        model.BillLists = new List<PMSBillList>();
                    }
                    else
                    {
                        model.BillList = obill;
                        model.BillLists = PMSBL;
                    }
                }


                return View(model);
            }
            else
            {
                model.MedDetail = Cls_Admin.FetchMedicine(Convert.ToString(id));
                model.MedCode = model.MedDetail.MedCode;
                model.MedName = model.MedDetail.MedName;
                model.MedPrice = model.MedDetail.MedPrice;
                model.MedStock = model.MedDetail.MedStock;
                model.MedDetails = Cls_Admin.ViewMedicine();
                if (model.BillList == null)
                {
                    PMSBillList obill = new PMSBillList();
                    obill.ID = 0;
                    obill.Name = "";
                    obill.Price = 0;
                    obill.Qty = 0;
                    obill.Total = 0;
                    model.BillList = obill;
                    IList<PMSBillList> PMSBL = new List<PMSBillList>();
                    PMSBL = Session["billdata"] as List<PMSBillList>;
                    model.BillLists = PMSBL;
                }
                else
                {
                    IList<PMSBillList> PMSBL = new List<PMSBillList>();
                    PMSBL = Session["billdata"] as IList<PMSBillList>;
                    model.BillLists = PMSBL;
                }

                return View(model);
            }
        }
        public ActionResult AddToBill([Bind(Include = "MedCode,MedStock,MedPrice,MedName,MedQty,BillDate")] PMSMed modelPMS)
        {

            int FinalQty = modelPMS.MedStock - modelPMS.MedQty;

            if (FinalQty > -1)
            {
                Cls_Seller.UpdateStock(modelPMS.MedCode, FinalQty);
                PMSBillList bill = new PMSBillList();
                bill.ID = Convert.ToInt32(modelPMS.MedCode);
                bill.Name = modelPMS.MedName;
                bill.Qty = modelPMS.MedQty;
                bill.Price = modelPMS.MedPrice;
                bill.Total = bill.Qty * bill.Price;
                Session["billamount"] = Convert.ToInt32(Session["billamount"]) + bill.Total;
                IList<PMSBillList> PMSBL = new List<PMSBillList>();
                PMSBL = Session["billdata"] as IList<PMSBillList>;
                PMSBL.Add(bill);
                Session["billdata"] = PMSBL;
                Session["billdate"] = Convert.ToDateTime("2024-08-09");
            }
            else
            {
                TempData["Error"] = "Invalid Quantity";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Reset()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Print()
        {
            Billing_details pmsBill = new Billing_details();
            pmsBill.BillDate = Convert.ToDateTime(Session["billdate"]);
            pmsBill.Seller = Convert.ToInt32(Session["seller"]);
            pmsBill.Amount = Convert.ToInt32(Session["billamount"]);
            //pmsBill.Seller_details = new Seller_details();
            Cls_Seller.SaveBill(pmsBill);
            return RedirectToAction("Index");
        }
    }
}
