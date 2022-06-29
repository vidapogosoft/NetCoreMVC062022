using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages1.Pages.Registrado
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Models.Registrado> ListRegistrados { get; set; }

        public void OnGet()
        {
            //Llamado hacia mis apis

        }
    }
}
