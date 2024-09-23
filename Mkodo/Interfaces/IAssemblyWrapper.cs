using MkodoShared.Models;

namespace Mkodo.Interfaces;

public interface IAssemblyWrapper
{
    Stream? GetManifestResourceStream(string resourceName);
}
