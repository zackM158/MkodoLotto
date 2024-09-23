using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mkodo.Interfaces;
using Mkodo.Models;
using MkodoShared.Extensions;
using MkodoShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mkodo.Services;

public class LottoLocalDataService(IAssemblyWrapper assemblyWrapper,
    ILogger<LottoLocalDataService> logger) : ILottoDataService
{
    public async Task<List<DrawDto>> GetDrawsAsync()
    {
        var resourceName = "Mkodo.data.json";

        try
        {
            using (var stream = assemblyWrapper.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    logger?.LogWarning($"Resource {resourceName} not found.");
                    return new List<DrawDto>();
                }

                using (var reader = new StreamReader(stream))
                {
                    var json = await reader.ReadToEndAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true
                    };

                    var data = JsonSerializer.Deserialize<DrawsResponse>(json, options);
                    if (data == null || !data.Draws.Any()) return new List<DrawDto>();

                    return data.Draws.Select(d => d.ToDrawDto()).OrderByDescending(d => d.DrawDate).ToList();
                }
            }
        }
        catch (JsonException ex)
        {
            logger?.LogError(ex, "Failed to deserialize the JSON.");
            return new List<DrawDto>();
        }
        catch (Exception ex)
        {
            logger?.LogError(ex, "An unexpected error occurred while loading draws.");
            return new List<DrawDto>();
        }
    }
}
