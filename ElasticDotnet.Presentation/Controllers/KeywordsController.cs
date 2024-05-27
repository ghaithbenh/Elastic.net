using ElasticDotnet.Application.Keyword.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElasticDotnet.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeywordsController : ControllerBase
{
    private readonly ISender _sender;

    public KeywordsController(ISender sender)
    {
        _sender = sender;
    }

    [Authorize(Policy = ClaimTypes.Role)]
    [HttpGet]
    public async Task<IActionResult> GetAllKeywords()
    {
        var keywords = await _sender.Send(new GetKeywordsQuery());
        return Ok(keywords);
    }
}
