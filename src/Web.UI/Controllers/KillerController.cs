using System.Web.Mvc;
using Core.Data;
using Core.Domain;

namespace Web.UI.Controllers
{
    public class KillerController : Controller
    {
        readonly KillerRepository _killerRepository;

        public KillerController(KillerRepository killerRepository)
        {
            _killerRepository = killerRepository;
        }

        public ActionResult Index()
        {
           return View("Index", _killerRepository.GetAll());
        }
    }
}