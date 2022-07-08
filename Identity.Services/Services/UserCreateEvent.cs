using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Identity;
using Identity.Services.Post;
using Identity.Model;
using System.Threading;

namespace Identity.Services.Services
{
    public class UserCreateEvent : IRequestHandler<UserCreatePost, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

       public UserCreateEvent(

           UserManager<ApplicationUser> usermanager

           )
       {
            _userManager = usermanager;
       }

        public async Task<IdentityResult> Handle(UserCreatePost notif, CancellationToken cancel)
        {
            var entry = new ApplicationUser
            {
                FirstName = notif.FirstName,
                LastName = notif.LastName,
                Email = notif.Email,
                UserName = notif.Email

            };

            return await _userManager.CreateAsync(entry, notif.Password);

        }


    }
}
