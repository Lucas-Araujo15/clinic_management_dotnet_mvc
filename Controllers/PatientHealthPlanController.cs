using ClinicManagementMVC.Models;
using ClinicManagementMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementMVC.Controllers
{
    public class PatientHealthPlanController : Controller
    {
        private readonly ILogger<PatientHealthPlanController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public PatientHealthPlanController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/patienthealth/create")]
        public async Task<IActionResult> Create()
        {
            var viewModel = await LoadCreatePatientHealthPlanViewModelAsync();
            return View(viewModel);
        }

        [HttpPost("/patienthealth/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePatientHealthPlanViewModel request)
        {
            var viewModel = await LoadCreatePatientHealthPlanViewModelAsync();

            if (request.CreatePatientHealthPlanRequest.HealthPlanId != 0 && request.CreatePatientHealthPlanRequest.PatientId != 0)
            {
                var client = _clientFactory.CreateClient("APIClient");
                HttpResponseMessage response = await client.PostAsJsonAsync("api/patienthealthplans", request.CreatePatientHealthPlanRequest);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Vínculo criado com sucesso!";
                    return View(viewModel);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível adicionar o paciente");
                }
            }

            return View(viewModel);
        }

        private async Task<CreatePatientHealthPlanViewModel> LoadCreatePatientHealthPlanViewModelAsync()
        {
            var client = _clientFactory.CreateClient("APIClient");
            var viewModel = new CreatePatientHealthPlanViewModel();

            // Carrega a lista de pacientes
            HttpResponseMessage responsePatients = await client.GetAsync("api/patients/");
            if (responsePatients.IsSuccessStatusCode)
            {
                viewModel.Patients = await responsePatients.Content.ReadFromJsonAsync<List<Patient>>();
            }

            // Carrega a lista de planos de saúde
            HttpResponseMessage responseHealthPlans = await client.GetAsync("api/healthplans/");
            if (responseHealthPlans.IsSuccessStatusCode)
            {
                viewModel.HealthPlans = await responseHealthPlans.Content.ReadFromJsonAsync<List<HealthPlan>>();
            }

            return viewModel;
        }
    }
}
