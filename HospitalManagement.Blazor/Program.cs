using HospitalManagement.Blazor.Data;
using HospitalManagement.Blazor.Services;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// JSON options (DateOnly converters you already had)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new NullableDateOnlyJsonConverter());
    });

// ---- UI services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ToastService>();

static Uri BuildBaseUri(IConfiguration cfg)
{
    var url = cfg["ApiBaseUrl"];
    if (string.IsNullOrWhiteSpace(url))
        throw new InvalidOperationException("ApiBaseUrl is missing in configuration.");
    if (!url.EndsWith("/")) url += "/";
    return new Uri(url, UriKind.Absolute);
}

// Default HttpClient (useful if any page injects plain HttpClient)
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = BuildBaseUri(builder.Configuration) });

// Existing typed clients
builder.Services.AddHttpClient<PatientsApiClient>(c =>
{
    c.BaseAddress = BuildBaseUri(builder.Configuration);
});
builder.Services.AddHttpClient<BillingsApiClient>(c =>
{
    c.BaseAddress = BuildBaseUri(builder.Configuration);
});
builder.Services.AddHttpClient<DashboardApiClient>(c =>
{
    c.BaseAddress = BuildBaseUri(builder.Configuration);
});

// NEW: AppointmentsApiClient (typed client used by the page below)
builder.Services.AddHttpClient<AppointmentsApiClient>(c =>
{
    c.BaseAddress = BuildBaseUri(builder.Configuration);
});

builder.Services.AddHttpClient<CommonApiClient>(c =>
{
    c.BaseAddress = BuildBaseUri(builder.Configuration);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
