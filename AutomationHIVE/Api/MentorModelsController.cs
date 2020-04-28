using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutomationCodeHive.Models;
using AutomationHIVE.Data.Data.Migrations;  

namespace AutomationCodeHive.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorModelsController : ControllerBase
    {
        private readonly AutomationCodeHiveDbContext _context;

        public MentorModelsController(AutomationCodeHiveDbContext context)
        {
            _context = context;
        }

        // GET: api/MentorModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorModel>>> GetMentors()
        {
            return await _context.Mentors.ToListAsync();
        }

        // GET: api/MentorModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MentorModel>> GetMentorModel(int id)
        {
            var mentorModel = await _context.Mentors.FindAsync(id);

            if (mentorModel == null)
            {
                return NotFound();
            }

            return mentorModel;
        }

        // PUT: api/MentorModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMentorModel(int id, MentorModel mentorModel)
        {
            if (id != mentorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(mentorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentorModelExists(id))
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

        // POST: api/MentorModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MentorModel>> PostMentorModel(MentorModel mentorModel)
        {
            _context.Mentors.Add(mentorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMentorModel", new { id = mentorModel.Id }, mentorModel);
        }

        // DELETE: api/MentorModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MentorModel>> DeleteMentorModel(int id)
        {
            var mentorModel = await _context.Mentors.FindAsync(id);
            if (mentorModel == null)
            {
                return NotFound();
            }

            _context.Mentors.Remove(mentorModel);
            await _context.SaveChangesAsync();

            return mentorModel;
        }

        private bool MentorModelExists(int id)
        {
            return _context.Mentors.Any(e => e.Id == id);
        }
    }
}
