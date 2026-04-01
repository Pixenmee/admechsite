using AdMechSite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

public class SeguidorController : Controller
{
    private CultMechanicusContext db = new CultMechanicusContext();

    // LISTAR
    public ActionResult Index()
    {
        return View(db.Seguidores.ToList());
    }

    // DETALHES
    public ActionResult Details(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Seguidor seguidor = db.Seguidores.Find(id);

        if (seguidor == null)
            return HttpNotFound();

        return View(seguidor);
    }

    // CREATE (GET)
    public ActionResult Create()
    {
        return View();
    }

    // CREATE (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Seguidor seguidor)
    {
        if (ModelState.IsValid)
        {
            try
            {
                db.Seguidores.Add(seguidor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao salvar no banco.");
            }
        }

        return View(seguidor);
    }

    // EDIT (GET)
    public ActionResult Edit(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Seguidor seguidor = db.Seguidores.Find(id);

        if (seguidor == null)
            return HttpNotFound();

        return View(seguidor);
    }

    // EDIT (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Seguidor seguidor)
    {
        if (ModelState.IsValid)
        {
            try
            {
                db.Entry(seguidor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao atualizar.");
            }
        }

        return View(seguidor);
    }

    // DELETE (GET)
    public ActionResult Delete(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Seguidor seguidor = db.Seguidores.Find(id);

        if (seguidor == null)
            return HttpNotFound();

        return View(seguidor);
    }

    // DELETE (POST)
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        try
        {
            Seguidor seguidor = db.Seguidores.Find(id);
            db.Seguidores.Remove(seguidor);
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