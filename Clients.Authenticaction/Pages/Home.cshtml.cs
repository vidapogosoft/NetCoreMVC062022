using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clients.Authenticaction.Pages
{
    public class HomeModel : PageModel
    {
        public string tokenout { get; set; }

        public void OnGet(string token)
        {
            tokenout = token;

        }
    }
}
