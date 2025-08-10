using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using HospitalManagement.Blazor.DTO;

namespace HospitalManagement.Blazor.Services
{
    public class BillingsApiClient
    {
        private readonly HttpClient _http;

        public BillingsApiClient(HttpClient http) => _http = http;

        public Task<List<BillingMiniDto>?> GetAllAsync()
            => _http.GetFromJsonAsync<List<BillingMiniDto>>("api/billings");

        public Task<BillingDto?> GetAsync(int id)
            => _http.GetFromJsonAsync<BillingDto>($"api/billings/{id}");

        public async Task<List<BillingMiniDto>?> FilterAsync(
            int? patientId = null, DateTime? date = null,
            DateTime? from = null, DateTime? to = null, bool? paid = null)
        {
            var query = new Dictionary<string, string>();
            if (patientId.HasValue) query["patientId"] = patientId.Value.ToString();
            if (date.HasValue) query["date"] = date.Value.ToString("yyyy-MM-dd");
            if (from.HasValue) query["from"] = from.Value.ToString("yyyy-MM-dd");
            if (to.HasValue) query["to"] = to.Value.ToString("yyyy-MM-dd");
            if (paid.HasValue) query["paid"] = paid.Value.ToString().ToLowerInvariant();

            var url = QueryHelpers.AddQueryString("api/billings/filter", query);
            return await _http.GetFromJsonAsync<List<BillingMiniDto>>(url);
        }        

        public async Task<int> CreateAsync(BillingEditDto model)
        {
            var resp = await _http.PostAsJsonAsync("api/billings", model);
            resp.EnsureSuccessStatusCode();
            return (await resp.Content.ReadFromJsonAsync<int>())!;
        }

        public async Task UpdateAsync(int id, BillingEditDto model)
        {
            var resp = await _http.PutAsJsonAsync($"api/billings/{id}", model);
            resp.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"api/billings/{id}");
            resp.EnsureSuccessStatusCode();
        }
    }
}
