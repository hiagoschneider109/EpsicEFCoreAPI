#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EpsicEFCoreAPI;
using EpsicEFCoreAPI.Data;
using EpsicEFCoreAPI.Models;

namespace EpsicEFCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly DataContext _context;

        public ResultController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Result
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetResults()
        {
            return await _context.Results.ToListAsync();
        }
        

        // GET: api/Result/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetResult(int id)
        {
            var result = await _context.Results.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpGet("subject/{id}")]
        public async Task<ActionResult<List<ResultViewModel>>> GetResultBySubjectId(int id)
        {
            var subject = await _context.Results.Where(e => e.SubjectId == id)
                .Select(s => new ResultViewModel
                {
                    Id = s.Id_Result,
                    IdSubject = s.SubjectId,
                    Num_Result = s.Num_Result,

                }).ToListAsync();



            if (subject == null)
            {
                return NotFound(StatusCodes.Status404NotFound);
            }

            return subject;
        }

        // PUT: api/Result/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResult(int id, AddResultDto request)
        {
            var result = await _context.Results.FindAsync(id);
            result.Num_Result = request.Num_Result;
            if (id != result.Id_Result)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }

            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(id))
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

        // POST: api/Result
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Result>> PostResult(AddResultDto result)
        {
            var subject = await _context.Subjects.FindAsync(result.SubjectId);
            if (User == null)
                return NotFound(StatusCodes.Status404NotFound);

            var newResult = new Result
            {
                Num_Result = result.Num_Result,
                Subject = subject
            };
            _context.Results.Add(newResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResult", new { id = newResult.Id_Result }, newResult);
        }

        // DELETE: api/Result/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            var result = await _context.Results.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Results.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultExists(int id)
        {
            return _context.Results.Any(e => e.Id_Result == id);
        }
    }
}
