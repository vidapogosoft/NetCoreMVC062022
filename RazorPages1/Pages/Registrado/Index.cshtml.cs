using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;
using RazorPages1.Models;

namespace RazorPages1.Pages.Registrado
{
    public class IndexModel : PageModel
    {
        string BaseUrl = "http://localhost:3849/";
        public IEnumerable<Models.Registrado> ListRegistrados { get; set; }

        public async Task<IActionResult> OnGet()
        {
            //Llamado hacia mis apis
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Registrado/");

                if(Res.IsSuccessStatusCode)
                {

                    var Response = Res.Content.ReadAsStringAsync().Result;

                    ListRegistrados = JsonConvert.DeserializeObject<List<Models.Registrado>>(Response);

                }

            }

            return Page();
        }
    }
}
