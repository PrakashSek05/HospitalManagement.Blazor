using System.Text.Json.Serialization;

namespace HospitalManagement.Blazor.DTO;

public class PatientListItemDto
{
    [JsonPropertyName("patientId")] public int PatientId { get; set; }
    [JsonPropertyName("fullName")] public string FullName { get; set; } = default!;
    [JsonPropertyName("mrn")] public string MRN { get; set; } = default!;
    [JsonPropertyName("phone")] public string? Phone { get; set; }
    [JsonPropertyName("dob")] public DateOnly? Dob { get; set; }
    [JsonPropertyName("last_AppointmentDate")] public DateTime? LastAppointmentDate { get; set; }
    [JsonPropertyName("last_BillingDate")] public DateTime? LastBillingDate { get; set; }
    [JsonPropertyName("gender")] public string? Gender { get; set; }
    [JsonPropertyName("address")] public string? Address { get; set; }
    [JsonPropertyName("latestVisitTime")] public DateTime? LatestVisitTime { get; set; }
    [JsonPropertyName("latestReason")] public string? LatestReason { get; set; }

    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("createdUtc")] public DateTime CreatedUtc { get; set; }
    [JsonPropertyName("updatedUtc")] public DateTime? UpdatedUtc { get; set; }
}


// DTOs for the UI — mirror API responses/requests

public class PatientMasterDto // GET /api/patients
{
    public int PatientId { get; set; }
    public string Mrn { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string? Phone { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime? UpdatedUtc { get; set; }
    public DateTime? LatestVisitTime { get; set; }
    public string? LatestReason { get; set; }
    public DateTime? Last_AppointmentDate { get; set; }
    public DateTime? Last_BillingDate { get; set; }
}

public class PatientDetailDto // GET /api/patients/{id}
{
    public int PatientId { get; set; }
    public string Mrn { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public DateTime? Dob { get; set; }
    public string? Gender { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime? UpdatedUtc { get; set; }
    public DateTime? LatestVisitTime { get; set; }
    public DateTime? Last_BillingDate { get; set; }
}

public class PatientUpdateDto
{
    public string FullName { get; set; } = default!;
    public DateOnly? Dob { get; set; }
    public string? Gender { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public bool Status { get; set; }
}

public sealed class PatientEditVm
{
    public int Id { get; set; }       
    public string Mrn { get; set; } = "";
    public string FullName { get; set; } = "";
    public DateOnly? Dob { get; set; }              
    public string? Gender { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public bool Status { get; set; }
}


public class PatientCreateDto
{
    public string Mrn { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public DateOnly? Dob { get; set; }
    public string? Gender { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public bool Status { get; set; } = true;
}
