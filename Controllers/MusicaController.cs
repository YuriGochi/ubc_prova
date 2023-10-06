using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ubc.Models;

namespace ubc.Controllers
{
    public class MusicaController : Controller
    {

        private readonly AppDbContext _context;

        public MusicaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Index()
        {
            var musicas = _context.Musicas.ToList();
            return View(musicas);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> Create(Musica musica)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Musicas.Add(musica);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Algo deu errado {ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, $"Algo deu errado, modelo inválido");
            return View(musica);
        }
    }
}