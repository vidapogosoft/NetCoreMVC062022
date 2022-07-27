using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using System.Text.Json;
using System.Text;

using UIRazorPages.Models;

namespace UIRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public DatosPersonales ModelDatosPersonales { get; set; }

        [BindProperty]
        public DatosContacto ModelDatosContacto { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPostAsync()
        {
            DatosPersonales();
            DatosContacto();
        }

        public IActionResult DatosPersonales()
        {
            try
            {

                using (var client = new HttpClient())
                {

                    var content = new StringContent
                    (
                        JsonSerializer.Serialize(ModelDatosPersonales),
                         Encoding.UTF8,
                        "application/json"
                    );

                    HttpResponseMessage Res = client.PostAsync("TU_API", content).GetAwaiter().GetResult();

                    if (Res.IsSuccessStatusCode)
                    {

                    }

                    return Page();

                }

            }
            catch (Exception)
            {

                return Page();
            }
        }

        public IActionResult DatosContacto()
        {
            try
            {
                using (var client = new HttpClient())
                {

                    var contentcontact = new StringContent
                    (
                        JsonSerializer.Serialize(ModelDatosContacto),
                         Encoding.UTF8,
                        "application/json"
                    );

                    HttpResponseMessage Rescontact = client.PostAsync("TU_API", contentcontact).GetAwaiter().GetResult();

                    if (Rescontact.IsSuccessStatusCode)
                    {

                    }

                    return Page();

                }

            }
            catch (Exception)
            {

                return Page();
            }
        }
    }
}
