using System;

namespace HospitalManagement.Blazor.DTO
{
    
    public class BillingMiniDto
    {
        public int BillingId { get; set; }
        public DateTime BillingDate { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime? AppointmentDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
    }

    
    public class BillingDto
    {
        public int BillingId { get; set; }
        public DateTime BillingDate { get; set; }
        public string? InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal NetAmount { get; set; }
        public bool Paid { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public int? AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }


    public class BillingEditDto
    {
        public int BillId { get; set; }              
        public int PatientId { get; set; }           
        public int? AppointmentId { get; set; }      
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal NetAmount { get; set; }
        public bool PaidFlag { get; set; }
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }
}
