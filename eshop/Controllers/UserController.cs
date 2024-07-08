using eshop.Data;
using eshop.Model;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly Context _context;
        public UserController(Context context)
        {
            _context = context;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(long id)
        {
            return _context.Users.Find(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public User Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public User Put([FromBody] User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}
