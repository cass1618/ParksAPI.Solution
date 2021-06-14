using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksAPI.Models;
using System.Linq;

namespace ParksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private readonly ParksAPIContext _db;

        public ParksController(ParksAPIContext db)
        {
          _db = db;
        }

    // GET api/parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string parkname, string size)
    {
      var query = _db.Parks.AsQueryable();

      if (parkname != null)
      {
        query = query.Where(entry => entry.ParkName == parkname);
      }

      if (size != null)
      {
        query = query.Where(entry => entry.Size == size);
      }      

        return await query.ToListAsync();
    }

    // POST api/parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
        _db.Parks.Add(park);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    // GET: api/Parks/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
        var park = await _db.Parks.FindAsync(id);

        if (park == null)
        {
            return NotFound();
        }

        return park;
    }

     // PUT: api/Parks/id
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park Park)
    {
        if (id != Park.ParkId)
        {
          return BadRequest();
        }

        _db.Entry(Park).State = EntityState.Modified;

        try
        {
          await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ParkExists(id))
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

    // DELETE: api/Parks/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
        var park = await _db.Parks.FindAsync(id);
        if (park == null)
        {
          return NotFound();
        }

        _db.Parks.Remove(park);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    private bool ParkExists(int id)
    {
        return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}