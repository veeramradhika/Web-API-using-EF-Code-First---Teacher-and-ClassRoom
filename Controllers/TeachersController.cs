using ApiEFDBProject;
using ApiEFDBProject.Entites;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProjectEFDb.APIModels;

namespace WebApiProjectEFDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApiDBContext _context;
        private readonly IMapper _mapper;
        public TeachersController(ApiDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teachers>>> GetTeacher()
        {
          if (_context.Teacher == null)
          {
              return NotFound();
          }

            var classRoom = _context.Teacher.Include(t => t.ClassRoomList).ToList();
            
            return(classRoom);
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teachers>> GetTeachers(int id)
        {
          if (_context.Teacher == null)
          {
              return NotFound();
          }
            var teacher = _context.Teacher.Where(t => t.ID == id).Include(cls => cls.ClassRoomList).FirstOrDefault();

            if (teacher == null)
            {
                return NotFound();
            }
            else
            {
                return _mapper.Map<Teachers>(teacher);
            }
            
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeachers(int Id, TeachersAndClassRoomAPIModel teachersAndClassRoomAPIModel)
        {
            
            var obj = _mapper.Map<Teachers>(teachersAndClassRoomAPIModel.Teacher);
            var list = _mapper.Map<List<ClassRoom>>(teachersAndClassRoomAPIModel.classRoomList);
            var ob = _context.Teacher.Where(t => t.ID == Id).Include(c => c.ClassRoomList).FirstOrDefault();


            if (Id != ob.ID)
            {
                return BadRequest();
            }
            ob.Address = obj.Address;
            ob.Name = obj.Name;
            ob.EmailId = obj.EmailId;

            ob.ClassRoomList = list;

            _context.Update(ob);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teachers>> PostTeachers(TeachersAndClassRoomAPIModel teachersAndClassRoomAPIModel)
        {
          if (_context.Teacher == null)
          {
              return Problem("Entity set 'ApiDBContext.Teacher'  is null.");
          }

          var teacher =_mapper.Map<Teachers>(teachersAndClassRoomAPIModel.Teacher);
            var classRoom = _mapper.Map < List<ClassRoom>>(teachersAndClassRoomAPIModel.classRoomList);
            teacher.ClassRoomList = classRoom;
            _context.Teacher.Add(teacher);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeachers(int id)
        {
            if (_context.Teacher == null)
            {
                return NotFound();
            }
            var teachers = await _context.Teacher.FindAsync(id);
            if (teachers == null)
            {
                return NotFound();
            }

            _context.Teacher.Remove(teachers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeachersExists(int id)
        {
            return (_context.Teacher?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
