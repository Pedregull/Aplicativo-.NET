using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recode_Api.Models;

namespace Recode_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : ControllerBase
    {
        private readonly DestinoDBContext _context;

        public DestinoController(DestinoDBContext context)
        {
            _context = context;
        }
        // GET: api/Destino - LISTA TODOS OS DESTINOS
        [HttpGet]
        public IEnumerable<Destino> GetDestino()
        {
            return _context.Destino;
        }

        // GET: api/Destino/id - LISTA DESTINO POR ID
        [HttpGet("{id}")]
        public IActionResult GetCursoPorId(int id)
        {
            Destino destino = _context.Destino.SingleOrDefault(modelo => modelo.DestinoId == id);
            if (destino == null)
            {
                return NotFound();
            }
            return new ObjectResult(destino);
        }

        // CRIA UM NOVO DESTINO
        [HttpPost]
        public IActionResult CriarDestino(Destino item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Destino.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

        }

        // ATUALIZA UM DESTINO EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaDestino(int id, Destino item)
        {
            if (id != item.DestinoId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        // APAGA UM DESTINO POR ID
        [HttpDelete("{id}")]
        public IActionResult DeletaDestino(int id)
        {
            var destino = _context.Destino.SingleOrDefault(m => m.DestinoId == id);

            if (destino == null)
            {
                return BadRequest();
            }

            _context.Destino.Remove(destino);
            _context.SaveChanges();
            return Ok(destino);
        }
    }
}
