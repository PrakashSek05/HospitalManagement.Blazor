using HospitalManagement.Blazor.DTO;
namespace HospitalManagement.Blazor.Services;

public class DashboardApiClient
{
    private readonly HttpClient _http;
    public DashboardApiClient(HttpClient http) => _http = http;
    
    public async Task<DashboardSummaryDto?> GetSummaryAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<DashboardSummaryDto>("api/dashboard/summary", ct);
}
