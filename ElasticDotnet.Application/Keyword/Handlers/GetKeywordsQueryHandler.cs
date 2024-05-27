using AutoMapper;
using ElasticDotnet.Application.Keyword.Queries;
using ElasticDotnet.Domain.Interfaces;
using ElasticDotnet.Domain.Models;
using MediatR;

namespace ElasticDotnet.Application.Keyword.Handlers;

internal sealed class GetKeywordsQueryHandler : IRequestHandler<GetKeywordsQuery, List<KeywordResponse>>
{
    private readonly IKeywordRepository _keywordRepository;
    private readonly IMapper _mapper;

    public GetKeywordsQueryHandler(IKeywordRepository keywordRepository, IMapper mapper)
    {
        _keywordRepository = keywordRepository;
        _mapper = mapper;
    }

    public async Task<List<KeywordResponse>> Handle(GetKeywordsQuery request, CancellationToken cancellationToken)
    {
        var keywords = await _keywordRepository.FindAllAsync(cancellationToken);
        return _mapper.Map<List<KeywordResponse>>(keywords);
    }
}
