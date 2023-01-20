using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityWebAPI.DataAccess;
using UniversityWebAPI.Models.DataAccess;
using UniversityWebAPI.Services;

namespace UniversityWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntitiesController : ControllerBase
    {
        private readonly UniversitysDBContext _context;
   

        public BaseEntitiesController(UniversitysDBContext context)
        {
            _context = context;
        }

        // GET: api/BaseEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseEntity>>> GetbaseEntities()
        {
            return await _context.baseEntities.ToListAsync();
        }


        // GET: api/BaseEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseEntity>> GetBaseEntity(int? id)
        {
            var baseEntity = await _context.baseEntities.FindAsync(id);

            if (baseEntity == null)
            {
                return NotFound();
            }

            return baseEntity;
        }

        // PUT: api/BaseEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseEntity(int? id, BaseEntity baseEntity)
        {
            if (id != baseEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseEntityExists(id))
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

        // POST: api/BaseEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseEntity>> PostBaseEntity(BaseEntity baseEntity)
        {
            _context.baseEntities.Add(baseEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseEntity", new { id = baseEntity.Id }, baseEntity);
        }

        // DELETE: api/BaseEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseEntity(int? id)
        {
            var baseEntity = await _context.baseEntities.FindAsync(id);
            if (baseEntity == null)
            {
                return NotFound();
            }

            _context.baseEntities.Remove(baseEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseEntityExists(int? id)
        {
            return _context.baseEntities.Any(e => e.Id == id);
        }
    }
}
