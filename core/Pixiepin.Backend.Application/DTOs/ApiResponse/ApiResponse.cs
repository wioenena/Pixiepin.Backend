
namespace Pixiepin.Backend.Application.DTOs.ApiResponse;

public sealed class ApiResponse<TData, TError>(TData? data, TError? error) {
    public bool IsSuccess => this.Error == null;
    public TData? Data { get; } = data;
    public TError? Error { get; } = error;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}
