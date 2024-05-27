using AutoMapper;
using ElasticDotnet.Domain.Models;

namespace ElasticDotnet.Application.Mappers.Profiles;

public sealed class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<AxamProduct, ProductResponse>();
        CreateMap<Domain.Entities.Keyword, KeywordResponse>();
    }
}
