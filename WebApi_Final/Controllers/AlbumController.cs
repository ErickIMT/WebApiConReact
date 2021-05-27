using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Final.Models;

namespace WebApi_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly MusicaContext _context;

        public AlbumController(MusicaContext context)
        {
            _context = context;
        }

        [HttpGet("albums")]
        public IEnumerable<QueryAlbums> ListarAlbumss()
        {
            List<QueryAlbums> query = (from a in _context.Albums
                                    join
                                    c in _context.Cantantes on a.CantanteId equals c.CantanteId
                                    join p in _context.Paises
                                    on a.PaisId equals p.PaisId
                                    join g in _context.Generos on a.GeneroId equals g.GeneroId
                                    select new QueryAlbums
                                    {
                                        albumid = a.AlbumId,
                                        albumtit=a.AlbumTit,
                                        albumfech = a.AlbumFec,
                                        cantanteid=c.CantanteId,
                                        cantantename=c.CantanteName,
                                        paisID=p.PaisId,
                                        paisnom=p.Pais_Nom,
                                        generoid=g.GeneroId,
                                        generoname=g.GeneroName,
                                        precio=a.Precio,
                                        tipo=a.Tipo,
                                        stock=a.stock,
                                    }).ToList();


            return query;
        }

        // GET: api/Album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        [HttpGet("paises")]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
        {
            return await _context.Paises.ToListAsync();
        }

        [HttpGet("generos")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGeneros()
        {
            return await _context.Generos.ToListAsync();

        }

        [HttpGet("cantantes")]
        public async Task<ActionResult<IEnumerable<Cantante>>> GetCantantes()
        {
            return await _context.Cantantes.ToListAsync();

        }


            // GET: api/Album/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(string id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Album/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(string id, Album album)
        {
            if (id != album.AlbumId)
            {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Album
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            _context.Albums.Add(album);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlbumExists(album.AlbumId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlbum", new { id = album.AlbumId }, album);
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(string id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumExists(string id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}
