namespace ElasticDotnet.Domain.Models;

public sealed class ProductWithScoreResponse
{
    public required ProductResponse Product { get; set; }
    public required double Score { get; set; }
}