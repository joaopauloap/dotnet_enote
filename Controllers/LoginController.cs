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
        public ActionResult<User> Login([FromBody] LoginDto loginDto)
        {
            User user = _context.Users
                .Where(x => x.Email.Equals(loginDto.Email) && x.Password.Equals(loginDto.Password))
                .FirstOrDefault();

            if (user == null)
            {
                return Unauthorized("Erro no login. Usuário ou senha incorretos!");
            }

            return user; ;
        }
    }
}
