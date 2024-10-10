namespace ClinicManagementMVC.Models.Request
{
    public class CreatePatientHealthPlanRequest
    {
        public int PatientId { get; set; }
        public int HealthPlanId { get; set; }
    }
}
