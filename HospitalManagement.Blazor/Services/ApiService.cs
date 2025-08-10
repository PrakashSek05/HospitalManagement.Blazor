using System.Net.Http.Json;
using System.Text.Json;

namespace HospitalManagement.Blazor.Services;

public class ApiService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _jsonOptions;

    public ApiService(HttpClient http)
    {
        _http = http;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<T?> GetAsync<T>(string url)
    {
        try
        {
            Console.WriteLine($"[GET] {url}");
            var result = await _http.GetFromJsonAsync<T>(url, _jsonOptions);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR][GET] {url} -> {ex.Message}");
            return default;
        }
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data)
    {
        try
        {
            Console.WriteLine($"[POST] {url} | Payload: {JsonSerializer.Serialize(data)}");
            var res = await _http.PostAsJsonAsync(url, data);
            Console.WriteLine($"[POST] Status: {res.StatusCode}");

            if (res.IsSuccessStatusCode)
                return await res.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);

            return default;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR][POST] {url} -> {ex.Message}");
            return default;
        }
    }

    public async Task<bool> PutAsync<TRequest>(string url, TRequest data)
    {
        try
        {
            Console.WriteLine($"[PUT] {url} | Payload: {JsonSerializer.Serialize(data)}");
            var res = await _http.PutAsJsonAsync(url, data);
            Console.WriteLine($"[PUT] Status: {res.StatusCode}");
            return res.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR][PUT] {url} -> {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteAsync(string url)
    {
        try
        {
            Console.WriteLine($"[DELETE] {url}");
            var res = await _http.DeleteAsync(url);
            Console.WriteLine($"[DELETE] Status: {res.StatusCode}");
            return res.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR][DELETE] {url} -> {ex.Message}");
            return false;
        }
    }
}
