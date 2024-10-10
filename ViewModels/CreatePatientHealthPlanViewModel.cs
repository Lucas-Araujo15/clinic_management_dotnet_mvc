using ClinicManagementMVC.Models;
using ClinicManagementMVC.Models.Request;

namespace ClinicManagementMVC.ViewModels
{
    public class CreatePatientHealthPlanViewModel
    {
        public CreatePatientHealthPlanRequest CreatePatientHealthPlanRequest { get; set; }
        public List<Patient> Patients { get; set; }
        public List<HealthPlan> HealthPlans { get; set; }
    }
}
