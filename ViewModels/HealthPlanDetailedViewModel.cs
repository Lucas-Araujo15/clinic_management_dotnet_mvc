using ClinicManagementMVC.Models;

namespace ClinicManagementMVC.ViewModels
{
    public class HealthPlanDetailedViewModel
    {
        public HealthPlan HealthPlan { get; set; }
        public List<PatientsOfAHealthPlan> Patients { get; set; }
    }
}
