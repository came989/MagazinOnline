using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProiectMIPFinal.Models;

namespace ProiectMIPFinal.Controllers
{
    public class PartiController : Controller
    {
        private PartiDbContext partidbctx= new PartiDbContext();
        // GET: Parti
        public ActionResult Index()
        {
            return View(partidbctx.PartiSet.ToList());
        }

        [HttpGet]

        public ActionResult Create() 
        {
            PartiModel parte= new PartiModel();
            return View(parte);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartiModel parte)
        {
            if (ModelState.IsValid)
            {
                partidbctx.PartiSet.Add(parte);
                partidbctx.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(parte);
        }
    }
}