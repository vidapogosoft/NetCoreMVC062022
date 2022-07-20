using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using Clients.Authenticaction.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace Clients.Authenticaction.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        [BindProperty(SupportsGet = true)]
        public string ReturnBaseUrl { get; set; }

        [BindProperty]
        public LoginViewModel model { get; set; }


        public bool HasInvalidAccess { get; set; }

        private readonly string _identityUrl;

        public IndexModel(
            ILogger<IndexModel> logger,
            IConfiguration configuration
            )
        {
            _logger = logger;
            _identityUrl = configuration.GetValue<string>("IdentityUrl");
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            try
            {

                using(var client = new HttpClient())
                {
                    var content = new StringContent
                    (
                        JsonSerializer.Serialize(model), 
                        Encoding.UTF8,
                         "application/json"
                    );

                    var request = await client.PostAsync(_identityUrl + "Identity/authentication", content);

                    if (!request.IsSuccessStatusCode)
                    {
                        HasInvalidAccess = true;
                        return Page();
                    }

                    var result = JsonSerializer.Deserialize<IdentityAccess>(

                        await request.Content.ReadAsStringAsync(),
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }

                        );

                    return Redirect(ReturnBaseUrl + $"Home?token={result.AccessToken}");
                }

            }
            catch (Exception)
            {
                return Page();
            }

        }
    }
}
