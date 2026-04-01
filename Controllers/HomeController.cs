using System.Linq;
using System.Web.Mvc;

public class HomeController : Controller
{
    private CultMechanicusContext db = new CultMechanicusContext();

    public ActionResult Index()
    {
        ViewBag.TotalSeguidores = db.Seguidores.Count();
        ViewBag.TotalDogmas = db.Dogmas.Count();
        ViewBag.TotalEscrituras = db.Escrituras.Count();
        ViewBag.TotalLouvores = db.Louvores.Count();

        return View();
    }
}