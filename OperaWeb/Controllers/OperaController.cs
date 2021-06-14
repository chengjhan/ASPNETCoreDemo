using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OperaWeb.Data;
using OperaWeb.Models;
using OperaWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperaWeb.Controllers
{
    public class OperaController : Controller
    {
        private readonly IOperaService _operaService;

        public OperaController(IOperaService operaService)
        {
            _operaService = operaService;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] string q)
        {
            return View(_operaService.Search(q));
        }

        [HttpGet, ActionName("detail")]
        public IActionResult Detail(int? id)
        {
            var opera = _operaService.FindById((int)id);

            return View(opera);
        }

        [HttpGet, ActionName("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("create")]
        public IActionResult Create(Opera opera)
        {
            _operaService.Create(opera);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, ActionName("edit")]
        public IActionResult Edit(int? id)
        {
            return View(_operaService.FindById((int)id));
        }

        [HttpPost, ActionName("edit")]
        public IActionResult Edit(Opera opera)
        {
            _operaService.Edit(opera);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, ActionName("delete")]
        public IActionResult Delete(int? id)
        {
            return View(_operaService.FindById((int)id));
        }

        [HttpPost, ActionName("delete")]
        public IActionResult Delete(int id)
        {
            _operaService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, ActionName("delete2")]
        public IActionResult Delete2(int? id)
        {
            _operaService.Delete((int)id);

            return RedirectToAction(nameof(Index));
        }
    }
}
