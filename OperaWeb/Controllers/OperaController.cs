using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OperaWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperaWeb.Controllers
{
    public class OperaController : Controller
    {
        private readonly OperaContext _context;

        public OperaController(OperaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Operas.ToList());
        }
    }
}
