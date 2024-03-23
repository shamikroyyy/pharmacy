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
    public class PMSSellersController : Controller
    {
        private PMSDBContext db = new PMSDBContext();

        // GET: Sellers
        public ActionResult Index(int? id)
        {
            PMSSeller model = new PMSSeller();
            if (id == null)
            {
                model.SelDetails = Cls_Admin.Viewseller();
                return View(model);
            }
            else
            {
                model.SelDetail = Cls_Admin.FetchSeller(Convert.ToInt32(id));
                model.SelId = model.SelDetail.SelId;
                model.SelName = model.SelDetail.SelName;
                model.SelEmail = model.SelDetail.SelEmail;
                model.SelPwd = model.SelDetail.SelPwd;
                model.SelDOB = model.SelDetail.SelDOB;
                model.SelGen= model.SelDetail.SelGen;
                model.SelAdd = model.SelDetail.SelAdd;
                model.SelDetails = Cls_Admin.Viewseller();
                return View(model);
            }
        }
 
        [HttpPost]
        public ActionResult Save([Bind(Include = "SelId,SelName,SelEmail,SelPwd,SelDOB,SelGen,SelAdd")] Seller_details pMSModel)
        {
            if (ModelState.IsValid)
            {
                Cls_Admin.AddSeller(pMSModel);
                return RedirectToAction("Index");
            }
            return View(pMSModel);
        }
 
 
        [HttpPost]
        public ActionResult Edit([Bind(Include = "SelId,SelName,SelEmail,SelPwd,SelDOB,SelGen,SelAdd")] PMSSeller pMSsel)
        {
            if (ModelState.IsValid)
            {
                Cls_Admin.UpdateSeller(pMSsel.SelId, pMSsel.SelName, pMSsel.SelEmail, pMSsel.SelPwd, pMSsel.SelDOB, pMSsel.SelGen, pMSsel.SelAdd);
                return RedirectToAction("Index");
            }
            return View(pMSsel);
        }
 
 
        [HttpPost]
        public ActionResult Delete([Bind(Include = "SelId,SelName,SelEmail,SelPwd,SelDOB,SelGen,SelAdd")] PMSSeller pMSsel)
        {
            if (ModelState.IsValid)
            {
                Cls_Admin.DeleteSeller(pMSsel.SelId);
                return RedirectToAction("Index");
            }
            return View(pMSsel);
        }
    }
}
