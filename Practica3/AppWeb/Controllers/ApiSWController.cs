using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using AppWeb.Models;

namespace AppWeb.Controllers
{
    public class ApiSWController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://swapi.dev/api/people");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic apiResponse = JsonConvert.DeserializeObject(content);

                    if (apiResponse != null && apiResponse.results != null)
                    {
                        var starWarsCharacterList = apiResponse.results.ToObject<List<PersonajesSW>>(); ;
                        return View("Index",starWarsCharacterList);
                    }
                }
                return null;
            }
        }
    }
}