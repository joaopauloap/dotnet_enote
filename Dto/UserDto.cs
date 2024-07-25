using eshop.Model;

namespace eshop.Dto
{
    public class UserDto
    {
        public UserDto() { }
        public UserDto(User user) { 
            this.Name = user.Name;
            this.Email = user.Email;
            this.Phone = user.Phone;
        }


        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
