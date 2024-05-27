using ElasticDotnet.Domain.Entities;

namespace ElasticDotnet.Domain.Interfaces;

public interface IKeywordRepository
{
    public Task<string> GetKeywordAsync(string keyword);
    public Task AddKeywordAsync(string keyword);
    public Task UpdateKeywordCountAsync(string keyword);
    public Task<List<Keyword>> FindAllAsync(CancellationToken cancellationToken);
}
