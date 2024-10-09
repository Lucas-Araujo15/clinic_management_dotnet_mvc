namespace ClinicManagementMVC.Models
{
    public class PatientsOfAHealthPlan
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public DateTime AccessionDate { get; set; }
    }
}
