using Microsoft.AspNetCore.Mvc;
using MkodoApi.Interfaces;
using MkodoShared.Extensions;

namespace MkodoApi.Controllers;

[Route("api/lotto")]
[ApiController]
public class LottoController : ControllerBase
{
    private readonly ILottoRepository lottoRepo;

    public LottoController(ILottoRepository lottoRepo)
    {
        this.lottoRepo = lottoRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetDraws()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var drawsResponse = await lottoRepo.GetDrawsAsync();

            if (drawsResponse.HasError || !drawsResponse.Draws.Any())
            {
                return BadRequest("There was an issue getting data");
            }

            var drawsDtos = drawsResponse.Draws.Select(s => s.ToDrawDto()).ToList();
            return Ok(drawsDtos);
        }
        catch
        {
            return BadRequest("There was an issue getting data");
        }
    }
}
