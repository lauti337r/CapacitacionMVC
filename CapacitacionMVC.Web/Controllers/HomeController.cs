namespace CapacitacionMVC.Web.Controllers
{
    using CapacitacionMVC.Data;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}