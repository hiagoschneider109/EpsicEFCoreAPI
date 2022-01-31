using EpsicEFCoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpsicEFCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly DataContext _context;

        public SubjectController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectViewModel>>> GetSubjects()
        {
            var subjects = await _context.Subjects.Select(u => new SubjectViewModel
            {
                Id = u.Id_Subject,
                IdUser = u.UserId,
                Subject = u.Name_Subject,
                Results = u.Results.Select(s => new ResultViewModel { Num_Result = s.Num_Result })
            })
                
                .ToListAsync();
            return subjects;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
           

            if (subject == null)
            {
                return NotFound(StatusCodes.Status404NotFound);
            }
            
            return subject;
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<List<SubjectViewModel>>> GetSubjectsByUserId(int id)
        {
            var subject = await _context.Subjects.Where(e => e.UserId == id)
                .Select(s => new SubjectViewModel
                {
                    Id = s.Id_Subject,
                    IdUser = s.UserId,
                    Subject = s.Name_Subject,
                    Results = s.Results.Select(s => new ResultViewModel { Num_Result = s.Num_Result})
                    
                }).ToListAsync();

            

            if (subject == null)
            {
                return NotFound(StatusCodes.Status404NotFound);
            }

            return subject;
        }



        [HttpPost]
        public async Task<ActionResult<IEnumerable<SubjectViewModel>>> Create(CreateSubjectDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound(StatusCodes.Status404NotFound);

            var newSubject = new Subject
            {
                Name_Subject = request.Name_Subject,
                User = user
            };

            _context.Subjects.Add(newSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubject", new {id = newSubject.Id_Subject}, newSubject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, CreateSubjectDto request)
        {
            var subject = await _context.Subjects.FindAsync(id);
            subject.Name_Subject = request.Name_Subject;
            if (id != subject.Id_Subject)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
                {
                    return NotFound(StatusCodes.Status404NotFound);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound(StatusCodes.Status404NotFound);
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.Id_Subject == id);
        }
    }
}


