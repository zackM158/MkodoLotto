using MkodoApi.Interfaces;
using MkodoShared.Models;
using System.Text.Json;

namespace MkodoApi.Repository;

public class LottoRepository : ILottoRepository
{
    private readonly IWebHostEnvironment env;

    public LottoRepository(IWebHostEnvironment env)
    {
        this.env = env;
    }

    public async Task<DrawsResponse> GetDrawsAsync()
    {
        var filePath = Path.Combine(env.ContentRootPath, "Data", "testdata.json");
        var jsonData = await System.IO.File.ReadAllTextAsync(filePath);

        //TODO add error handling and null checks
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        var data = JsonSerializer.Deserialize<DrawsResponse>(jsonData, options);
        return data ?? new DrawsResponse() { HasError = true };
    }
}
