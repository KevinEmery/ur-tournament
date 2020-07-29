using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoboticsTournamentWebsite.Models;
using Newtonsoft.Json.Linq;

// Roles: "Organizer", "Participant"

namespace RoboticsTournamentWebsite.Controllers
{
    public class ManageController : Controller
    {
        // Triggered when form is submitted
        [HttpPost]
        public async Task<ActionResult> Create(TournamentInfo tournamentInfo)
        {
            // Call toornament API here to create tournament here
            //JObject payload = new JObject(tournamentInfo);
            string jsonText = tournamentInfo.ToString();
            using (HttpClient httpClient = new HttpClient()) {
                var message = new StringContent(jsonText);
                string apiKey = Environment.GetEnvironmentVariable("TOORNAMENT_API_KEY");
                if (apiKey == null)
                {
                    return Content("No api key.");
                }
                message.Headers.Add("X-Api-Key", apiKey);
                await httpClient.PostAsync("https://api.toornament.com/organizer/v2/tournaments", message);
            }
            return View("Create");
        }
    }
}
