using MkodoShared.Models;

namespace MkodoApi.Interfaces;

public interface ILottoRepository
{
    public Task<DrawsResponse> GetDrawsAsync();
}
