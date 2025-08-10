using System.Net.Http.Json;
using HospitalManagement.Blazor.DTO;


namespace HospitalManagement.Blazor.Services;

public class PatientsApiClient
{
    private readonly HttpClient _http;

    public PatientsApiClient(HttpClient http) => _http = http;

    public async Task<List<PatientListItemDto>> GetAllAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<List<PatientListItemDto>>("api/patients", ct)
           ?? new List<PatientListItemDto>();

    public async Task<PatientListItemDto?> GetByIdAsync(int id, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<PatientListItemDto>($"api/patients/{id}", ct);

    public async Task<int> CreateAsync(PatientCreateDto model, CancellationToken ct = default)
    {
        var resp = await _http.PostAsJsonAsync("api/patients", model, ct);
        if (!resp.IsSuccessStatusCode) { return 0; } else
        {
            return 1;
        }
    }


    public async Task<bool> UpdateAsync(int id, PatientUpdateDto model, CancellationToken ct = default)
    {
        var resp = await _http.PutAsJsonAsync($"api/patients/{id}", model, ct);
        return resp.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var resp = await _http.DeleteAsync($"api/patients/{id}", ct);
        return resp.IsSuccessStatusCode;
    }
}
