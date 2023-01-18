using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProiectMIPFinal.Models;
using LoggingOperationsAssembly;

namespace ProiectMIPFinal.Controllers
{
    public class MasiniController : Controller
    {
        private MasiniDbContext masinidbctx = new MasiniDbContext();
        // GET: Masini
        public ActionResult Index()
        {
            bool log = LoggingOps.WriteLog(LoggingOps.filePath, "S-a apasat butonul Masini.");
            return View(masinidbctx.MasiniSet.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {
            MasiniModel masina = new MasiniModel();
            return View(masina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasiniModel masina)
        {
            if (ModelState.IsValid)
            {
                masinidbctx.MasiniSet.Add(masina);
                masinidbctx.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(masina);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            MasiniModel masina = masinidbctx.MasiniSet.Find(id);
            if (null == masina)
            {
                return HttpNotFound();
            }
            return View(masina);
        }

        [HttpPost]
        public ActionResult Edit(MasiniModel masina)
        {
            if (ModelState.IsValid)
            {
                masinidbctx.Entry(masina).State = System.Data.Entity.EntityState.Modified;
                masinidbctx.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(masina);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            MasiniModel masina = masinidbctx.MasiniSet.Find(id);
            if (null == masina)
            {
                return HttpNotFound();
            }
            return View(masina);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                MasiniModel masina = masinidbctx.MasiniSet.Find(id);
                masinidbctx.MasiniSet.Remove(masina);
                masinidbctx.SaveChanges();

            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            MasiniModel msg = masinidbctx.MasiniSet.Find(id);
            if (null == msg)
            {
                return HttpNotFound();
            }

            return View(msg);
        }
    }
}