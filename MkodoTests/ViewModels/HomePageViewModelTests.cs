using Mkodo.Interfaces;
using Mkodo.ViewModels;
using MkodoShared.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkodoTests.ViewModels;

public class HomePageViewModelTests
{
    private readonly ILottoDataService lottoDataService;
    private readonly ICacheService cache;
    private readonly HomePageViewModel viewModel;
    public HomePageViewModelTests()
    {
        lottoDataService = Substitute.For<ILottoDataService>();
        cache = Substitute.For<ICacheService>();

        viewModel = new HomePageViewModel(lottoDataService, cache);
    }

    [Fact]
    public async Task Initialize_ShowsError_WhenDrawsIsEmpty()
    {
        // Arrange
        lottoDataService.GetDrawsAsync().Returns(new List<DrawDto>());

        // Act
        await viewModel.GetDrawsCommand.ExecuteAsync(null);

        // Assert
        Assert.Empty(viewModel.Draws!);           
        Assert.True(viewModel.DrawsHasError);
        cache.DidNotReceive().Draws = Arg.Any<List<DrawDto>>();
    }

    [Fact]
    public async Task Initialize_SetsCorrectCurrentIndex_WhenPassedASelectedDraw()
    {
        // Arrange
        var mockDraws = new List<DrawDto>
        {
            new DrawDto { Id = "draw-1", TopPrize = 25494276, DrawDate = DateTime.Now, 
            Numbers = [ "1", "23", "45", "14", "52", "11" ], BonusBall = "26" },
            new DrawDto { Id = "draw-1", TopPrize = 37363624, DrawDate = DateTime.Now.AddDays(-1), 
            Numbers = [ "46", "23", "22", "27", "2", "4" ], BonusBall = "15" },
        };

        lottoDataService.GetDrawsAsync().Returns(mockDraws);

        // Act
        await viewModel.GetDrawsCommand.ExecuteAsync(null);

        // Assert
        Assert.Equal(mockDraws, viewModel.Draws);
        Assert.False(viewModel.DrawsHasError); 
        cache.Received(1).Draws = mockDraws; 
    }
}
