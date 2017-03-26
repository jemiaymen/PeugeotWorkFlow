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
    public class AchatController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Achat
        public async Task<ActionResult> Index()
        {
            var achats = db.Achats.Include(a => a.Department);
            return View(await achats.ToListAsync());
        }

        // GET: Achat/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achat achat = await db.Achats.FindAsync(id);
            if (achat == null)
            {
                return HttpNotFound();
            }
            return View(achat);
        }

        // GET: Achat/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Dep");
            return View();
        }

        // POST: Achat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,DepartmentID,Des,Categ,DtAcha,Creation,LieuLiv,Imp,Qte,Type")] Achat achat)
        {
            if (ModelState.IsValid)
            {
                db.Achats.Add(achat);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Dep", achat.DepartmentID);
            return View(achat);
        }

        // GET: Achat/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achat achat = await db.Achats.FindAsync(id);
            if (achat == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Dep", achat.DepartmentID);
            return View(achat);
        }

        // POST: Achat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,DepartmentID,Des,Categ,DtAcha,Creation,LieuLiv,Imp,Qte,Type")] Achat achat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(achat).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Dep", achat.DepartmentID);
            return View(achat);
        }

        // GET: Achat/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achat achat = await db.Achats.FindAsync(id);
            if (achat == null)
            {
                return HttpNotFound();
            }
            return View(achat);
        }

        // POST: Achat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Achat achat = await db.Achats.FindAsync(id);
            db.Achats.Remove(achat);
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
