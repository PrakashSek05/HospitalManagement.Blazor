using System.Net.Http.Json;
using HospitalManagement.Blazor.DTO;

namespace HospitalManagement.Blazor.Services;

public class CommonApiClient
{
    private readonly HttpClient _http;
    public CommonApiClient(HttpClient http) => _http = http;

    public Task<List<LookupItemDto>> GetPatientsAsync(CancellationToken ct = default)
        => _http.GetFromJsonAsync<List<LookupItemDto>>("api/common/patients", ct)!;

    public Task<List<LookupItemDto>> GetDoctorsAsync(CancellationToken ct = default)
        => _http.GetFromJsonAsync<List<LookupItemDto>>("api/common/doctors", ct)!;

    public Task<List<LookupItemDto>> GetDepartmentsAsync(CancellationToken ct = default)
        => _http.GetFromJsonAsync<List<LookupItemDto>>("api/common/departments", ct)!;

    public Task<List<LookupItemDto>> GetSpecialtiesAsync(CancellationToken ct = default)
        => _http.GetFromJsonAsync<List<LookupItemDto>>("api/common/specialties", ct)!;
}
