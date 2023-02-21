using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private DefaultDbContext _context;

    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetMovies() => _context.Movies.ToList();

    [HttpGet]
    [HttpGet("{id}")]
    public ActionResult<Movie> GetMovie(int id)
    {
        var movie = _context.Movies.Find(id);

        if (movie == null)
        {
            return NotFound();
        }

        return movie;
    }


    [HttpPost]
    public ActionResult<Movie> CreateMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovie), new
        {
            id = movie.Id
        }, movie);
    }


    // DELETE api/<MovieController>/5
    [HttpDelete("{id}")]
    public ActionResult<Movie> DeleteMovie(int id)
    {
        var movie = _context.Movies.Find(id);

        if (movie == null)
        {
            return NotFound();
        }

        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return movie;
    }
}