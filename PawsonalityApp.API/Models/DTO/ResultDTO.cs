namespace Pawsonality.API.Models;

public class ResultDTO
{

    public DateTime TimeStamp { get; set; }

    public string ResultValue { get; set; } = null!;

    public string? UserId { get; set; }
    
}