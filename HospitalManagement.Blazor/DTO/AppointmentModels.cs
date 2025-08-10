namespace HospitalManagement.UI.Models
{
    public abstract class AppointmentBaseVm
    {
        public string? DoctorName { get; set; }
        public DateTime? VisitDateTime { get; set; }
        public string? Status { get; set; }
        public string? Reason { get; set; }
    }

    public  class AppointmentMasterVm : AppointmentBaseVm
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = "";
        public int DoctorId { get; set; }
        public DateTime? LastVisitDateTime { get; set; }
        public string? LastDoctorName { get; set; }
        public bool? IsEdit { get; set; }
    }
    
    public  class AppointmentEditVm
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime VisitDateTime { get; set; } = DateTime.Now;
        public string? Status { get; set; } = "Scheduled";
        public string? Reason { get; set; }
    }


}
