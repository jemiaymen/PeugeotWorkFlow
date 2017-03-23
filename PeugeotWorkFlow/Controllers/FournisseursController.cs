using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PeugeotWorkFlow.Models;

namespace PeugeotWorkFlow.Controllers
{

    [Authorize(Roles = "Responsable Achat")]
    public class FournisseursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fournisseurs
        public async Task<ActionResult> Index()
        {
            return View(await db.Fournisseurs.ToListAsync());
        }

        // GET: Fournisseurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = await db.Fournisseurs.FindAsync(id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // GET: Fournisseurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fournisseurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Nom_frn,Adress_frn,Mail_frn,Tel_frn")] Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                db.Fournisseurs.Add(fournisseur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fournisseur);
        }

        // GET: Fournisseurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = await db.Fournisseurs.FindAsync(id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // POST: Fournisseurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nom_frn,Adress_frn,Mail_frn,Tel_frn")] Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fournisseur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fournisseur);
        }

        // GET: Fournisseurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = await db.Fournisseurs.FindAsync(id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // POST: Fournisseurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fournisseur fournisseur = await db.Fournisseurs.FindAsync(id);
            db.Fournisseurs.Remove(fournisseur);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
