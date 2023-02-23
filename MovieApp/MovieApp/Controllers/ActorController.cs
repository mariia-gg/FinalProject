using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorController : ControllerBase
{
    private readonly DefaultDbContext _context;

    public ActorController(DefaultDbContext context) => _context = context;

    // GET: api/Actor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Actor>>> GetActors() => await _context.Actors.ToListAsync();

    // GET: api/Actor/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Actor>> GetActor(Guid id)
    {
        var actor = await _context.Actors.FindAsync(id);

        if (actor == null)
        {
            return NotFound();
        }

        return actor;
    }

    // POST: api/Actor
    [HttpPost]
    public async Task<ActionResult<Actor>> PostActor(Actor actor)
    {
        _context.Actors.Add(actor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetActor), new
        {
            id = actor.Id
        }, actor);
    }

    // PUT: api/Actor/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutActor(Guid id, Actor actor)
    {
        if (id != actor.Id)
        {
            return BadRequest();
        }

        _context.Entry(actor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ActorExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // DELETE: api/Actor/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActor(Guid id)
    {
        var actor = await _context.Actors.FindAsync(id);

        if (actor == null)
        {
            return NotFound();
        }

        _context.Actors.Remove(actor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ActorExists(Guid id)
    {
        return _context.Actors.Any(e => e.Id == id);
    }
}

