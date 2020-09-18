using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using VILLANCICOS.Models;

namespace VILLANCICOS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            villancicosContext context = new villancicosContext();
            var villancicos = context.Villancico.OrderByDescending(x => x.Anyo);

            return View(villancicos);
        }
        public IActionResult Letra(int ? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index");
            }
            villancicosContext context = new villancicosContext();
            var villancico = context.Villancico.FirstOrDefault(x => x.Id == id);

            if (villancico==null)
            {
                return RedirectToAction("Index");
            }


            return View(villancico);
        }
    }
}
