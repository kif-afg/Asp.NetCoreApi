using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReFlow_testProject.Models;

namespace ReFlow_testProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly ReFlow_testProjectContext _context;

        public OwnersController(ReFlow_testProjectContext context)
        {
            _context = context;
        }

        // GET: api/Owners
        [HttpGet]
        [Authorize]
        public IEnumerable<Owner> GetOwner()
        {
            return _context.Owner;
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetOwner([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = await _context.Owner.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutOwner([FromRoute] int id, [FromBody] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != owner.id)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostOwner([FromBody] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Owner.Add(owner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwner", new { id = owner.id }, owner);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteOwner([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = await _context.Owner.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owner.Remove(owner);
            await _context.SaveChangesAsync();

            return Ok(owner);
        }

        private bool OwnerExists(int id)
        {
            return _context.Owner.Any(e => e.id == id);
        }
    }
}