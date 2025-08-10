// Services/ToastService.cs
using System;

namespace HospitalManagement.Blazor.Services;

public sealed class ToastService
{
    public event Action<ToastMessage>? OnShow;

    public void Show(ToastLevel level, string title, string message, int timeoutMs = 4000)
        => OnShow?.Invoke(new ToastMessage { Level = level, Title = title, Message = message, TimeoutMs = timeoutMs });

    public void Success(string message, string title = "Success", int timeoutMs = 3000)
        => Show(ToastLevel.Success, title, message, timeoutMs);

    public void Info(string message, string title = "Info", int timeoutMs = 4000)
        => Show(ToastLevel.Info, title, message, timeoutMs);

    public void Warning(string message, string title = "Warning", int timeoutMs = 5000)
        => Show(ToastLevel.Warning, title, message, timeoutMs);

    public void Error(string message, string title = "Error", int timeoutMs = 6000)
        => Show(ToastLevel.Error, title, message, timeoutMs);
}
