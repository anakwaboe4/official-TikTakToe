namespace TikTakToe.API.Models;

public record ErrorResponse
{
    public Guid CorrelationId { get; set; }
    public string? Message { get; set; }
}
