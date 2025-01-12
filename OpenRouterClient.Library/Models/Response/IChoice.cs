namespace OpenRouterClient.Library.Models.Response;

public interface IChoice
{
    public string? FinishReason { get; set; }

    public ErrorResponse? Error { get; set; }
}