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
    public class CinFController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CinF
        public async Task<ActionResult> Index()
        {
            var categoryInFournisseur = db.CategoryInFournisseur.Include(c => c.Category).Include(c => c.Fournisseur);
            return View(await categoryInFournisseur.ToListAsync());
        }

        // GET: CinF/Details/5
        public async Task<ActionResult> Details(int? idc,int? idf)
        {
            if (idc == null || idf == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryInFournisseur categoryInFournisseur = await db.CategoryInFournisseur.FindAsync(idc,idf);
            if (categoryInFournisseur == null)
            {
                return HttpNotFound();
            }
            return View(categoryInFournisseur);
        }

        // GET: CinF/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Lbl");
            ViewBag.FournisseurID = new SelectList(db.Fournisseurs, "ID", "Nom_frn");
            return View();
        }

        // POST: CinF/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CategoryID,FournisseurID")] CategoryInFournisseur categoryInFournisseur)
        {
            if (ModelState.IsValid)
            {
                db.CategoryInFournisseur.Add(categoryInFournisseur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Lbl", categoryInFournisseur.CategoryID);
            ViewBag.FournisseurID = new SelectList(db.Fournisseurs, "ID", "Nom_frn", categoryInFournisseur.FournisseurID);
            return View(categoryInFournisseur);
        }

        // GET: CinF/Edit/5
        public async Task<ActionResult> Edit(int? idc, int? idf)
        {
            if (idc == null || idf == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryInFournisseur categoryInFournisseur = await db.CategoryInFournisseur.FindAsync(idc, idf);
            if (categoryInFournisseur == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Lbl", categoryInFournisseur.CategoryID);
            ViewBag.FournisseurID = new SelectList(db.Fournisseurs, "ID", "Nom_frn", categoryInFournisseur.FournisseurID);
            return View(categoryInFournisseur);
        }

        // POST: CinF/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CategoryID,FournisseurID")] CategoryInFournisseur categoryInFournisseur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryInFournisseur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Lbl", categoryInFournisseur.CategoryID);
            ViewBag.FournisseurID = new SelectList(db.Fournisseurs, "ID", "Nom_frn", categoryInFournisseur.FournisseurID);
            return View(categoryInFournisseur);
        }

        // GET: CinF/Delete/5
        public async Task<ActionResult> Delete(int? idc,int? idf)
        {
            if (idc == null || idf == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryInFournisseur categoryInFournisseur = await db.CategoryInFournisseur.FindAsync(idc,idf);
            if (categoryInFournisseur == null)
            {
                return HttpNotFound();
            }
            return View(categoryInFournisseur);
        }

        // POST: CinF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int idc ,int idf)
        {
            CategoryInFournisseur categoryInFournisseur = await db.CategoryInFournisseur.FindAsync(idc, idf);
            db.CategoryInFournisseur.Remove(categoryInFournisseur);
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
