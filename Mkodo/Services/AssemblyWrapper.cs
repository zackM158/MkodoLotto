using Microsoft.Extensions.Configuration;
using Mkodo.Interfaces;
using Mkodo.Models;
using MkodoShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mkodo.Services;

public class AssemblyWrapper : IAssemblyWrapper
{
    public Stream? GetManifestResourceStream(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return assembly.GetManifestResourceStream(resourceName);
    }
}
