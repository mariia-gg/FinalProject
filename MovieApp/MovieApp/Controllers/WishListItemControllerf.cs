using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WishListItemControllerf : ControllerBase
{
    private readonly DefaultDbContext _context;

    public WishListItemControllerf(DefaultDbContext context) => _context = context;

    //// GET: api/Cart
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<WishListItem>>> GetCarts() => await _context.WishListItems.ToListAsync();

    // GET: api/Cart/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WishListItem>> GetCart(Guid id)
    {
        var wishListItem = await _context.WishListItems.FindAsync(id);

        if (wishListItem == null)
        {
            return NotFound();
        }

        return wishListItem;
    }

    // POST: api/Cart
    [HttpPost]
    public async Task<ActionResult<WishListItem>> PostCart(WishListItem wishListItem)
    {
        _context.WishListItems.Add(wishListItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCart), new
        {
            id = wishListItem.Id
        }, wishListItem);
    }

    // PUT: api/Cart/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCart(Guid id, WishListItem wishListItem)
    {
        if (id != wishListItem.Id)
        {
            return BadRequest();
        }

        _context.Entry(wishListItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CartExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // DELETE: api/Cart/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCart(Guid id)
    {
        var wishListItem = await _context.WishListItems.FindAsync(id);

        if (wishListItem == null)
        {
            return NotFound();
        }

        _context.WishListItems.Remove(wishListItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CartExists(Guid id)
    {
        return _context.WishListItems.Any(e => e.Id == id);
    }
}

