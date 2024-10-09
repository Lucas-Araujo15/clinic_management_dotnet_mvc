using ClinicManagementMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementMVC.Controllers
{
    public class HealthPlanController : Controller
    {
        private readonly ILogger<HealthPlanController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HealthPlanController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("APIClient");
            List<HealthPlan> healthPlans = null;

            HttpResponseMessage response = await client.GetAsync("api/healthplans");

            if (response.IsSuccessStatusCode)
            {
                healthPlans = await response.Content.ReadFromJsonAsync<List<HealthPlan>>();
            }

            return View(healthPlans);
        }
    }
}
