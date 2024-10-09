namespace ClinicManagementMVC.Models
{
    public class HealthPlansOfAPatient
    {
        public int Id { get; set; }
        public HealthPlan HealthPlan { get; set; }
        public DateTime AccessionDate { get; set; }

    }
}
