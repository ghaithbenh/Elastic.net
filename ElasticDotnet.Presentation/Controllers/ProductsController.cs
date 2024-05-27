using AutoMapper;
using ElasticDotnet.Application.Elasticsearch.Queries;
using ElasticDotnet.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ElasticDotnet.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ProductsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [Authorize(Policy = ClaimTypes.Role)]
    [HttpGet("admin/cosine_search")]
    public async Task<IActionResult> GetAllProductsCosineSimAdmin(
        [FromQuery(Name = "q")] string searchQuery,
        [FromQuery(Name = "num_candidates_desc")] int numCandidatesDesc = 25,
        [FromQuery(Name = "num_candidates_prodlabel")] int numCandidatesProdLabel = 25,
        [FromQuery(Name = "top_res_desc")] int topResDesc = 20,
        [FromQuery(Name = "top_res_prodlabel")] int topResProdLabel = 10
    )
    {
        var knnSearchRequest = new KnnSearchRequest(
            NumCandidatesDesc: numCandidatesDesc,
            NumCandidatesProdLabel: numCandidatesProdLabel,
            TopResDesc: topResDesc,
            TopResProdLabel: topResProdLabel
        );
        var getProductsQuery = new GetProductsQuery(searchQuery, knnSearchRequest);

        var response = await _sender.Send(getProductsQuery);

        if (response.IsValid)
        {
            var productsWithScores = response.Hits
             .Select(hit => new ProductWithScoreResponse
             {
                 Product =_mapper.Map<ProductResponse>(hit.Source),
                 Score = hit.Score.GetValueOrDefault()
             });

            return Ok(productsWithScores);
        }

        Console.WriteLine("Error in search query: " + response.DebugInformation);
        return BadRequest();
    }


    [HttpGet("cosine_search")]
    public async Task<IActionResult> GetAllProductsCosineSim([FromQuery(Name = "q")] string searchQuery)
    {
        var knnSearchRequest = new KnnSearchRequest(
            NumCandidatesDesc: 25,
            NumCandidatesProdLabel: 25,
            TopResDesc: 20,
            TopResProdLabel: 10
        );
        var getProductsQuery = new GetProductsQuery(searchQuery, knnSearchRequest);

        var response = await _sender.Send(getProductsQuery);

        if (response.IsValid)
        {
            var productsWithScores = response.Hits
             .Select(hit => new ProductWithScoreResponse
             {
                 Product =_mapper.Map<ProductResponse>(hit.Source),
                 Score = hit.Score.GetValueOrDefault() // Make sure your hit includes the score
             });

            return Ok(productsWithScores);
        }

        Console.WriteLine("Error in search query: " + response.DebugInformation);
        return BadRequest();
    }

}