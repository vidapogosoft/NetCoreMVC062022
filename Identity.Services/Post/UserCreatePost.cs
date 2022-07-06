using Microsoft.AspNetCore.Identity;
using MediatR;

using System.ComponentModel.DataAnnotations;

namespace Identity.Services.Post
{
    public class UserCreatePost : IRequest<IdentityResult>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
