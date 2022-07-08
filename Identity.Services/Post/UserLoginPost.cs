
using MediatR;
using Identity.Services.Response;

using System.ComponentModel.DataAnnotations;

namespace Identity.Services.Post
{
    public class UserLoginPost : IRequest<IdentityAccess>
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
