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

public class CacheService : ICacheService
{
    public List<DrawDto>? Draws { get; set; }
}
