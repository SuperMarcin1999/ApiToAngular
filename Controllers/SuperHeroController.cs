using ApiToAngular.Data;
using ApiToAngular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiToAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Post(SuperHero superHero)
        {
            _context.SuperHeroes.Add(superHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPatch]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero superHero)
        {
            var foundSH = await _context.SuperHeroes.FindAsync(superHero.Id);

            if (foundSH is null)
                return NotFound();

            foundSH.FirstName = superHero.FirstName;
            foundSH.LastName = superHero.LastName;
            foundSH.Name = superHero.Name;
            foundSH.Place = superHero.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var foundSH = await _context.SuperHeroes.FindAsync(id);

            if ( foundSH is null) 
                return NotFound();

            _context.SuperHeroes.Remove(foundSH);
            await _context.SaveChangesAsync();
            return Ok(_context.SuperHeroes.ToListAsync());
        }
    }
}
