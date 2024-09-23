using MkodoShared.Models;

namespace Mkodo.Interfaces;

public interface ICacheService
{
    public List<DrawDto>? Draws { get; set; }
}
