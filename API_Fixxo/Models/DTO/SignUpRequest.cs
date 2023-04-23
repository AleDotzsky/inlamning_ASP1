using API_Fixxo.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace API_Fixxo.Models.DTO
{
    public class SignUpRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string RoleName { get; set; } = "user";

        public static implicit operator CustomIdentityUser(SignUpRequest request)
        {
            return new CustomIdentityUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email,
            };
        }
    }
}
