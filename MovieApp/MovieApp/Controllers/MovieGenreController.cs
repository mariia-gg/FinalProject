using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieGenreController : ControllerBase
{
    private readonly DefaultDbContext _context;

    public MovieGenreController(DefaultDbContext context) => _context = context;

    // GET: api/MovieGenre
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieGenre>>> GetMovieGenres() =>
        await _context.MovieGenres.ToListAsync();

    // GET: api/MovieGenre/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieGenre>> GetMovieGenre(Guid id)
    {
        var movieGenre = await _context.MovieGenres.FindAsync(id);

        if (movieGenre == null)
        {
            return NotFound();
        }

        return movieGenre;
    }

    // POST: api/MovieGenre
    [HttpPost]
    public async Task<ActionResult<MovieGenre>> PostMovieGenre(MovieGenre movieGenre)
    {
        _context.MovieGenres.Add(movieGenre);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMovieGenre), new
        {
            id = movieGenre.Id
        }, movieGenre);
    }

    // PUT: api/MovieGenre/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMovieGenre(Guid id, MovieGenre movieGenre)
    {
        if (id != movieGenre.Id)
        {
            return BadRequest();
        }

        _context.Entry(movieGenre).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieGenreExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // DELETE: api/MovieGenre/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovieGenre(Guid id)
    {
        var movieGenre = await _context.MovieGenres.FindAsync(id);

        if (movieGenre == null)
        {
            return NotFound();
        }

        _context.MovieGenres.Remove(movieGenre);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MovieGenreExists(Guid id)
    {
        return _context.MovieGenres.Any(e => e.Id == id);
    }
}