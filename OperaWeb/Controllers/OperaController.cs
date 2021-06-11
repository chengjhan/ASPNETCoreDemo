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

        public IActionResult Index()
        {
            return View(_operaService.List());
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
    }
}
