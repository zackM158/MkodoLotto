using MkodoShared.Models;

namespace MkodoApi.Interfaces;

public interface IDataService
{
    public Task<List<Draw>> GetDrawsAsync();
}
