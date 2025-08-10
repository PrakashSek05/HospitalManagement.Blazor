using HospitalManagement.UI.Models;
using System.Net.Http.Json;

namespace HospitalManagement.Blazor.Services;

public class AppointmentsApiClient
{
    private readonly HttpClient _http;
    public AppointmentsApiClient(HttpClient http) => _http = http;

    // GET: api/appointments
    public async Task<List<AppointmentMasterVm>> GetAllAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<List<AppointmentMasterVm>>("api/appointments", ct)
           ?? new();

    // GET: api/appointments/{id}
    public Task<AppointmentMasterVm?> GetAsync(int id, CancellationToken ct = default)
        => _http.GetFromJsonAsync<AppointmentMasterVm>($"api/appointments/{id}", ct);

    // GET: api/appointments/filter?patientId=&doctorId=&onlyOpen=
    public async Task<List<AppointmentMasterVm>> FilterAsync(int? patientId, int? doctorId, bool onlyOpen, CancellationToken ct = default)
    {
        var qs = new List<string>();
        if (patientId.HasValue) qs.Add($"patientId={patientId.Value}");
        if (doctorId.HasValue) qs.Add($"doctorId={doctorId.Value}");
        if (onlyOpen) qs.Add("onlyOpen=true");
        var url = "api/appointments/filter" + (qs.Count > 0 ? "?" + string.Join("&", qs) : "");
        return await _http.GetFromJsonAsync<List<AppointmentMasterVm>>(url, ct) ?? new();
    }

    // POST: api/appointments
    public async Task<int> CreateAsync(AppointmentEditVm model, CancellationToken ct = default)
    {
        var resp = await _http.PostAsJsonAsync("api/appointments", model, ct);
        resp.EnsureSuccessStatusCode();
        // API returns CreatedAtAction + model.AppointmentId as content; we only need success
        // If you want the id, read it:
        var id = await resp.Content.ReadFromJsonAsync<int>(cancellationToken: ct);
        return id;
    }

    // PUT: api/appointments/{id}
    public async Task UpdateAsync(int id, AppointmentEditVm model, CancellationToken ct = default)
    {
        var resp = await _http.PutAsJsonAsync($"api/appointments/{id}", model, ct);
        resp.EnsureSuccessStatusCode();
    }
}
