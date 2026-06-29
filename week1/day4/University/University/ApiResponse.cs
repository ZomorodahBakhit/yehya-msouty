namespace University.Api;
public class ApiResponse
{
    public bool Success { get; set; } = true;
    public object? Data { get; set; }
    public string? Message { get; set; }

    public ApiResponse(object? data)
    {
        Data = data;
    }

    public ApiResponse(string message)
    {
        Message = message;
    }
}