
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
    public class PMSMedsController : Controller
    {
        private PMSDBContext db = new PMSDBContext();

        public ActionResult Index(int? id)
        {
            PMSMed model = new PMSMed();
            if (id == null)
            {
                model.MedDetails = Cls_Admin.ViewMedicine();
                return View(model);
            }
            else
            {
                model.MedDetail = Cls_Admin.FetchMedicine(Convert.ToString(id));
                model.MedCode = model.MedDetail.MedCode;
                model.MedName = model.MedDetail.MedName;
                model.MedPrice = model.MedDetail.MedPrice;
                model.MedStock = model.MedDetail.MedStock;
                model.MedExpDate = model.MedDetail.MedExpDate;
                model.MedCategory = model.MedDetail.MedCategory;
                model.MedDetails = Cls_Admin.ViewMedicine();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Save([Bind(Include = "MedCode,MedName,MedPrice,MedStock,MedExpDate,MedCategory")] Med_details pMSModel)
        {
            if (ModelState.IsValid)
            {
                Cls_Admin.AddMedicine(pMSModel);
                return RedirectToAction("Index");
                //return View(clsadmin.ViewMedicines());
            }

            return View(pMSModel);
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "MedCode,MedName,MedPrice,MedStock,MedExpDate,MedCategory")] PMSMed pMSMed)
        {
            if (ModelState.IsValid)
            {
                Cls_Admin.UpdateMedicine(pMSMed.MedCode, pMSMed.MedName, pMSMed.MedPrice, pMSMed.MedStock, pMSMed.MedExpDate, pMSMed.MedCategory);
                return RedirectToAction("Index");
            }
            return View(pMSMed);
        }


        [HttpPost]
        public ActionResult Delete([Bind(Include = "MedCode,MedName,MedPrice,MedStock,MedExpDate,MedCategory")] PMSMed pMSMed)
        {
            if (ModelState.IsValid)
            {
                Cls_Admin.DeleteMedicine(pMSMed.MedCode);
                return RedirectToAction("Index");
            }
            return View(pMSMed);
        }
    }
}
