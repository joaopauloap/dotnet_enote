using eshop.Data;
using eshop.Dto;
using eshop.Model;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<UserDto> Login([FromBody] LoginDto loginDto)
        {
            User user = _context.Users
                .Where(x => x.Email.Equals(loginDto.Email) && x.Password.Equals(loginDto.Password))
                .FirstOrDefault();

            if (user == null)
            {
                return Unauthorized("Usuário ou senha incorretos!");
            }

            return new UserDto(user); ;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<User> Register([FromBody] User user)
        {

            //TODO fazer validação de user

            _context.Users.Add(user);
            _context.SaveChanges();

            return user; ;
        }
    }
}
