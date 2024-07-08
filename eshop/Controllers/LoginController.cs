using eshop.Data;
using eshop.Dto;
using eshop.Model;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public User Login([FromBody] LoginDto loginDto)
        {
            return _context.Users
                .Where(x => x.Email.Equals(loginDto.Email) && x.Password.Equals(loginDto.Password))
                .FirstOrDefault();
        }
    }
}
