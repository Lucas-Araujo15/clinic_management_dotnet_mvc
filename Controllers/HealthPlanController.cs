using ClinicManagementMVC.Models;
using ClinicManagementMVC.Models.Request;
using ClinicManagementMVC.ViewModels;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateHealthPlanRequest healthPlan)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                HttpResponseMessage response = await client.PostAsJsonAsync("api/healthplans", healthPlan);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível adicionar o plano de saúde");
                }
            }

            return View(healthPlan);
        }

        [HttpGet("healthplans/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                HttpResponseMessage response = await client.DeleteAsync("api/healthplans/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível excluir o plano de saúde");
                }
            }

            return View();
        }

        [HttpGet("healthplans/edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            HttpResponseMessage response = await client.GetAsync("api/healthplans/" + id);
            HealthPlan healthPlan = null;

            if (response.IsSuccessStatusCode)
            {
                healthPlan = await response.Content.ReadFromJsonAsync<HealthPlan>();
            }

            return View(healthPlan);
        }

        [HttpPost("healthplans/update/{id}")]
        public async Task<IActionResult> Update(int id, HealthPlan healthPlan)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                HttpResponseMessage response = await client.PutAsJsonAsync("api/healthplans/" + id, healthPlan);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível editar o plano de saúde");
                }
            }

            return View("Index");
        }

        [HttpGet("healthplans/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            HealthPlanDetailedViewModel healthPlanDetailed = new HealthPlanDetailedViewModel();

            HttpResponseMessage responseHealthPlan = await client.GetAsync("api/healthplans/" + id);
         
            if (responseHealthPlan.IsSuccessStatusCode)
            {
                healthPlanDetailed.HealthPlan = await responseHealthPlan.Content.ReadFromJsonAsync<HealthPlan>();
            }

            HttpResponseMessage responseHealthPlanWithPatients = await client.GetAsync("api/patienthealthplans/patients/" + id);


            if (responseHealthPlanWithPatients.IsSuccessStatusCode)
            {
                healthPlanDetailed.Patients = await responseHealthPlanWithPatients.Content.ReadFromJsonAsync<List<PatientsOfAHealthPlan>>();
            }

            return View(healthPlanDetailed);
        }

        [HttpGet("healthplan/{healthPlanId}/patienthealthplan/{patientHealthPlanId}")]
        public async Task<IActionResult> DeletePatientHealthPlan(int healthPlanId, int patientHealthPlanId)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                HttpResponseMessage response = await client.DeleteAsync("api/patienthealthplans/" + patientHealthPlanId);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Detail", new { id = healthPlanId });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível excluir a associação");
                }
            }

            return RedirectToAction("Detail", new { id = healthPlanId });
        }
    }
}
