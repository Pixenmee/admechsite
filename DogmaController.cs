using AdMechSite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

public class DogmaController : Controller
{
    private CultMechanicusContext db = new CultMechanicusContext();

    // LISTAR
    public ActionResult Index()
    {
        return View(db.Dogmas.ToList());
    }

    // DETALHES
    public ActionResult Details(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Dogma dogma = db.Dogmas.Find(id);

        if (dogma == null)
            return HttpNotFound();

        return View(dogma);
    }

    // CREATE (GET)
    public ActionResult Create()
    {
        return View();
    }

    // CREATE (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Dogma dogma)
    {
        if (ModelState.IsValid)
        {
            try
            {
                db.Dogmas.Add(dogma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao salvar.");
            }
        }

        return View(dogma);
    }

    // EDIT (GET)
    public ActionResult Edit(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Dogma dogma = db.Dogmas.Find(id);

        if (dogma == null)
            return HttpNotFound();

        return View(dogma);
    }

    // EDIT (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Dogma dogma)
    {
        if (ModelState.IsValid)
        {
            try
            {
                db.Entry(dogma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao atualizar.");
            }
        }

        return View(dogma);
    }

    // DELETE (GET)
    public ActionResult Delete(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Dogma dogma = db.Dogmas.Find(id);

        if (dogma == null)
            return HttpNotFound();

        return View(dogma);
    }

    // DELETE (POST)
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        try
        {
            Dogma dogma = db.Dogmas.Find(id);
            db.Dogmas.Remove(dogma);
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