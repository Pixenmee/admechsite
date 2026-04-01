using AdMechSite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

public class EscrituraController : Controller
{
    private CultMechanicusContext db = new CultMechanicusContext();

    public ActionResult Index()
    {
        return View(db.Escrituras.ToList());
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Escritura escritura = db.Escrituras.Find(id);

        if (escritura == null)
            return HttpNotFound();

        return View(escritura);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Escritura escritura)
    {
        if (ModelState.IsValid)
        {
            try
            {
                db.Escrituras.Add(escritura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao salvar.");
            }
        }

        return View(escritura);
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Escritura escritura = db.Escrituras.Find(id);

        if (escritura == null)
            return HttpNotFound();

        return View(escritura);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Escritura escritura)
    {
        if (ModelState.IsValid)
        {
            try
            {
                db.Entry(escritura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao atualizar.");
            }
        }

        return View(escritura);
    }

    public ActionResult Delete(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Escritura escritura = db.Escrituras.Find(id);

        if (escritura == null)
            return HttpNotFound();

        return View(escritura);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        try
        {
            Escritura escritura = db.Escrituras.Find(id);
            db.Escrituras.Remove(escritura);
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