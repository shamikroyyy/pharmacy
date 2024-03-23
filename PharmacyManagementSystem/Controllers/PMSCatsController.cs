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
    public class PMSCatsController : Controller
    {
        private PMSDBContext db = new PMSDBContext();

        // GET: Category
        public ActionResult Index(int? id)
        {
            PMSCat model = new PMSCat();
            if (id == null)
            {
                model.CatDetails = Cls_Admin.ViewCategory();
                return View(model);
            }
            else
            {
                model.CatDetail = Cls_Admin.FetchCategory(Convert.ToInt32(id));
                model.CatId = model.CatDetail.CatId;
                model.CatName = model.CatDetail.CatName;
                model.CatDetails = Cls_Admin.ViewCategory();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Save([Bind(Include = "CatId,CatName")] Category_details pMSModel)
        {
            if (ModelState.IsValid)
            {
                Cls_Admin.AddCategory(pMSModel);

                return RedirectToAction("Index");

                //return View(clsadmin.ViewMedicines());
            }

            return View(pMSModel);
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "CatId,CatName")] PMSCat pMSCat)
        {
            if (ModelState.IsValid)
            {
                Cls_Admin.UpdateCategory(pMSCat.CatId, pMSCat.CatName);
                return RedirectToAction("Index");
            }
            return View(pMSCat);
        }


        [HttpPost]
        public ActionResult Delete([Bind(Include = "CatId,CatName")] PMSCat pMSCat)
        {
            if (ModelState.IsValid)
            {
                Cls_Admin.DeleteCategory(pMSCat.CatId);
                return RedirectToAction("Index");
            }
            return View(pMSCat);
        }
    }
}
