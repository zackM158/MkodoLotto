using MkodoShared.Models;

namespace Mkodo.Interfaces;

public interface ILottoDataService
{
    public Task<List<DrawDto>> GetDrawsAsync();
}
