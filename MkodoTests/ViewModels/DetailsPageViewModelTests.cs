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

public class DetailsPageViewModelTests
{
    private readonly ICacheService cache;
    private readonly DetailsPageViewModel viewModel;
    public DetailsPageViewModelTests()
    {
        cache = Substitute.For<ICacheService>();
        viewModel = new DetailsPageViewModel(cache);
    }

    [Fact]
    public void Initialize_ShowsError_WhenDrawsIsEmpty()
    {
        // Arrange
        cache.Draws.Returns((List<DrawDto>?)null);
        viewModel.SelectedDraw = new DrawDto { Id = "draw-1" }; 

        // Act
        viewModel.Initialize();

        // Assert
        Assert.Null(viewModel.Draws);                          
        Assert.True(viewModel.DrawsHasError);
        Assert.Equal(0, viewModel.CurrentIndex);
    }

    [Fact]
    public void Initialize_ShowsError_WhenSelectedDrawIsEmpty()
    {
        // Arrange
        var mockDraws = new List<DrawDto>
        {
            new DrawDto { Id = "draw-1" }
        };

        cache.Draws.Returns(mockDraws);
        viewModel.SelectedDraw = null;

        // Act
        viewModel.Initialize();

        // Assert
        Assert.Equal(mockDraws, viewModel.Draws);
        Assert.True(viewModel.DrawsHasError); 
        Assert.Equal(0, viewModel.CurrentIndex);
    }

    [Fact]
    public void Initialize_WhenNoDraws_SetsDrawsHasErrorToTrue()
    {
        // Arrange
        var emptyDraws = new List<DrawDto>();
        cache.Draws.Returns(emptyDraws);
        viewModel.SelectedDraw = new DrawDto { Id = "draw-1" };

        // Act
        viewModel.Initialize();

        // Assert
        Assert.Empty(viewModel.Draws!);
        Assert.True(viewModel.DrawsHasError);
        Assert.Equal(0, viewModel.CurrentIndex);
    }

    [Fact]
    public void Initialize_WhenDrawsExistAndSelectedDrawIsSet_SetsCorrectIndexAndNoError()
    {
        // Arrange
        var mockDraws = new List<DrawDto>
        {
            new DrawDto { Id = "draw-1" },
            new DrawDto { Id = "draw-2" },
            new DrawDto { Id = "draw-3" }
        };

        cache.Draws.Returns(mockDraws);
        viewModel.SelectedDraw = mockDraws[1];

        // Act
        viewModel.Initialize();

        // Assert
        Assert.Equal(mockDraws, viewModel.Draws);
        Assert.Equal(1, viewModel.CurrentIndex);
        Assert.False(viewModel.DrawsHasError);       
    }
}
