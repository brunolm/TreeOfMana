using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeOfMana.Dependencies;
using TreeOfMana.Dependencies.Models;
using TreeOfMana.Web;

namespace TreeOfMana.Controllers
{
    [ControllerExportAttribute(typeof(HomeController))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        private readonly ISkillService skillService;

        [ImportingConstructor]
        public HomeController(ISkillService skillService)
        {
            this.skillService = skillService;
            skillService.Test();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}