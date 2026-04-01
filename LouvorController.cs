using AdMechSite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

public class LouvorController : Controller
{
    private CultMechanicusContext db = new CultMechanicusContext();

    public ActionResult Index()
    {
        return View(db.Louvores.ToList());
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Louvor louvor = db.Louvores.Find(id);

        if (louvor == null)
            return HttpNotFound();

        return View(louvor);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Louvor louvor)
    {
        if (ModelState.IsValid)
        {
            try
            {
                db.Louvores.Add(louvor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao salvar.");
            }
        }

        return View(louvor);
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Louvor louvor = db.Louvores.Find(id);

        if (louvor == null)
            return HttpNotFound();

        return View(louvor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Louvor louvor)
    {
        if (ModelState.IsValid)
        {
            try
            {
                db.Entry(louvor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao atualizar.");
            }
        }

        return View(louvor);
    }

    public ActionResult Delete(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Louvor louvor = db.Louvores.Find(id);

        if (louvor == null)
            return HttpNotFound();

        return View(louvor);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        try
        {
            Louvor louvor = db.Louvores.Find(id);
            db.Louvores.Remove(louvor);
            db.SaveChanges();
        }
        catch
        {
            ModelState.AddModelError("", "Erro ao excluir.");
        }

        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            db.Dispose();

        base.Dispose(disposing);
    }
}