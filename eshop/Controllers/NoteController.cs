using eshop.Data;
using eshop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        private readonly Context _context;
        public NoteController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Note> GetAll()
        {
            return _context.Notes;
        }

        [HttpGet("{id}")]
        public Note Get(long id)
        {
            return _context.Notes.Where(x=>x.Id == id).Include(x=>x.User).FirstOrDefault();
        }

        [HttpPost]
        public Note Create(NoteDto noteDto)
        {
            Note note = new Note(noteDto);
            _context.Notes.Add(note);
            _context.SaveChanges();
            return note;
        }

        [HttpPut]
        public Note Update(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
            return note;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Note note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
