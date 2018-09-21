using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Filters;

namespace Projeto.Presentation.Areas.AreaRestrita.Controllers
{
    [Authorize]
    public class PrincipalController : Controller
    {
        // GET: AreaRestrita/Principal
        [NoCache]
        public ActionResult Index()
        {
            return View();
        }
    }
}