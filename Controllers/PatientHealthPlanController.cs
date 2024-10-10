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

        public async Task<IActionResult> Create()
        {
            var client = _clientFactory.CreateClient("APIClient");
            CreatePatientHealthPlanViewModel viewModel = new CreatePatientHealthPlanViewModel();
            HttpResponseMessage responsePatients = await client.GetAsync("api/patients/");

            if (responsePatients.IsSuccessStatusCode)
            {
                viewModel.Patients = await responsePatients.Content.ReadFromJsonAsync<List<Patient>>();
            }

            HttpResponseMessage responseHealthPlans = await client.GetAsync("api/healthplans/");

            if (responseHealthPlans.IsSuccessStatusCode)
            {
                viewModel.HealthPlans = await responseHealthPlans.Content.ReadFromJsonAsync<List<HealthPlan>>();
            }

            return View(viewModel);
        }
    }
}
