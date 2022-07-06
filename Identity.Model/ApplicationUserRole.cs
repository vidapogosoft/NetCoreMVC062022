using Microsoft.AspNetCore.Identity;

namespace Identity.Model
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationRole Role { get; set; }
        public ApplicationRole User { get; set; }
    }
}
