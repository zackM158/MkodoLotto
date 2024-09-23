using MkodoShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkodoShared.Extensions;

public static class DrawExtensions
{
    public static DrawDto ToDrawDto(this Draw draw)
    {
        return new DrawDto
        {
            Id = draw.Id,
            Numbers = draw.Numbers,
            BonusBall = draw.BonusBall,
            DrawDate = draw.DrawDate,
            TopPrize = draw.TopPrize
        };
    }

    public static DrawDto ToDrawDto(this DrawDataObject draw)
    {
        return new DrawDto
        {
            Id = draw.Id,
            Numbers =
            [
                draw.Number1,
                draw.Number2,
                draw.Number3,
                draw.Number4,
                draw.Number5,
                draw.Number6
            ],
            BonusBall = draw.BonusBall,
            DrawDate = draw.DrawDate,
            TopPrize = draw.TopPrize
        };
    }
}
