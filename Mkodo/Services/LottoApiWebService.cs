using Microsoft.Extensions.Configuration;
using Mkodo.Interfaces;
using Mkodo.Models;
using MkodoShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mkodo.Services;

public class LottoApiWebService : ILottoDataService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient httpClient;
    private readonly string baseUrl;
    public LottoApiWebService(IConfiguration config)
    {
        this._configuration = config;

        httpClient = new HttpClient();
        baseUrl = config.GetRequiredSection("BaseUrl").Get<string>()!;
    }

    public async Task<List<DrawDto>> GetDrawsAsync()
    {
        string url = $"{baseUrl}lotto";
        try
        {
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<List<DrawDto>>(jsonString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true
                });

                //todo handle null, 404 code etc
                return result!;
            }
            else
            {
                return new List<DrawDto>();
            }
        }
        catch(Exception ex)
        {
            var t = ex.Message;
            return new List<DrawDto>();
        }
    }
}
