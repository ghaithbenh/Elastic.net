using ElasticDotnet.Domain.Models;
using MediatR;

namespace ElasticDotnet.Application.Keyword.Queries;

public record GetKeywordsQuery : IRequest<List<KeywordResponse>>;
