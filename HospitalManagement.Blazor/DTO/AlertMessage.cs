namespace HospitalManagement.Blazor.Services;

public enum ToastLevel { Success, Warning, Error }

public sealed class ToastMessage
{
    public ToastLevel Level { get; init; }
    public string Title { get; init; } = "";
    public string Message { get; init; } = "";
    public int TimeoutMs { get; init; } = 3500; // auto-hide
}
