using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Recode_MVC_Dot_Net.Models;

namespace Recode_MVC_Dot_Net.Controllers
{
    public class DestinoController : Controller
    {
        private readonly DestinoDBContext _context;

        public DestinoController(DestinoDBContext context)
        {
            _context = context;
        }

        //GET Destino
        public IActionResult Index()
        {
            return View(_context.Destino.ToList());
        }

        // GET: Destino/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("DestinoId,NomeDoDestino")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destino);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(destino);
        }
        // GET: Destino/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Destino == null)
            {
                return NotFound();
            }

            var destino = _context.Destino.Find(id);
            if (destino == null)
            {
                return NotFound();
            }
            return View(destino);

        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("DestinoId,NomeDoDestino")] Destino destino)
        {
            if (id != destino.DestinoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destino);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoExists(destino.DestinoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(destino);
        }

        private bool DestinoExists(int destinoId)
        {
            throw new NotImplementedException();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Destino == null)
            {
                return NotFound();
            }

            var destino = _context.Destino.FirstOrDefault(m => m.DestinoId == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Destino == null)
            {
                return Problem("Entity set 'DestinoDBContext.Destino'  is null.");
            }
            var destino = _context.Destino.Find(id);
            if (destino != null)
            {
                _context.Destino.Remove(destino);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Destino == null)
            {
                return NotFound();
            }

            var destino = _context.Destino.FirstOrDefault(m => m.DestinoId == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

    }
}
