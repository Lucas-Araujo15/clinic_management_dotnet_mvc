using ClinicManagementMVC.Models;

namespace ClinicManagementMVC.ViewModels
{
    public class PatientDetailedViewModel
    {
        public Patient Patient { get; set; }
        public List<HealthPlansOfAPatient> HealthPlans { get; set; }
    }
}
