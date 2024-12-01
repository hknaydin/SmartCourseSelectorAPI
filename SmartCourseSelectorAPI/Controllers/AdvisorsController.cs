using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCourseSelectorWeb.Models;

namespace SmartCourseSelectorWeb.Controllers
{
    [Route("api/AdvisorController")]
    [ApiController]
    public class AdvisorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvisorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AdvisorController/getAdvisorList
        [HttpGet("getAdvisorList")]
        public async Task<ActionResult<IEnumerable<Advisor>>> GetAdvisors()
        {
            return await _context.Advisors.ToListAsync();
        }

        // GET: api/AdvisorController/getById?id=5
        [HttpGet("getById")]
        public async Task<ActionResult<Advisor>> GetAdvisor(int id)
        {
            var advisor = await _context.Advisors.FindAsync(id);

            if (advisor == null)
            {
                return NotFound(new { Message = "Advisor not found." });
            }

            return advisor;
        }

        // POST: api/AdvisorController
        [HttpPost]
        public async Task<ActionResult<Advisor>> CreateAdvisor(Advisor advisor)
        {
            _context.Advisors.Add(advisor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdvisor", new { id = advisor.AdvisorID }, advisor);
        }

        // PUT: api/AdvisorController/updateAdvisor?id=5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdvisor(int id, Advisor advisor)
        {
            if (id != advisor.AdvisorID)
            {
                return BadRequest(new { Message = "Advisor ID mismatch." });
            }

            _context.Entry(advisor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvisorExists(id))
                {
                    return NotFound(new { Message = "Advisor not found." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/AdvisorController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvisor(int id)
        {
            var advisor = await _context.Advisors.FindAsync(id);
            if (advisor == null)
            {
                return NotFound(new { Message = "Advisor not found." });
            }

            _context.Advisors.Remove(advisor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdvisorExists(int id)
        {
            return _context.Advisors.Any(e => e.AdvisorID == id);
        }
    }
}