using ElasticDotnet.Domain.Entities;
using ElasticDotnet.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElasticDotnet.Infrastructure.Repositories;

public sealed class KeywordRepository : IKeywordRepository
{
    private readonly ApplicationDbContext _dbContext;

    public KeywordRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddKeywordAsync(string keyword)
    {
        var existingKeyword = await _dbContext.Keywords.FirstOrDefaultAsync(k => k.Word == keyword);
        if (existingKeyword == null)
        {
            var newKeyword = new Keyword { Word = keyword, Count = 1 };
            _dbContext.Keywords.Add(newKeyword);
        }
        else
        {
            existingKeyword.Count++;
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task<string> GetKeywordAsync(string keyword)
    {
        var keywordEntity = await _dbContext.Keywords
            .AsNoTracking()
            .FirstOrDefaultAsync(k => k.Word == keyword);

        return keywordEntity?.Word;
    }

    public async Task UpdateKeywordCountAsync(string keyword)
    {
        var keywordEntity = await _dbContext.Keywords.FirstOrDefaultAsync(k => k.Word == keyword);
        if (keywordEntity != null)
        {
            keywordEntity.Count++;
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException($"The keyword '{keyword}' was not found.");
        }
    }
    public async Task<List<Keyword>> FindAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Keywords.AsNoTracking().ToListAsync(cancellationToken);
    }
}
