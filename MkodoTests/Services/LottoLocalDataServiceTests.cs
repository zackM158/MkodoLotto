using Microsoft.Extensions.Logging;
using Mkodo.Interfaces;
using Mkodo.Services;
using NSubstitute;
using System.Text;

namespace MkodoTests.Services;

public class LottoLocalDataServiceTests
{
    private readonly IAssemblyWrapper assemblyWrapper;
    private readonly ILogger<LottoLocalDataService> logger;
    private readonly LottoLocalDataService service;

    public LottoLocalDataServiceTests()
    {
        assemblyWrapper = Substitute.For<IAssemblyWrapper>();
        logger = Substitute.For<ILogger<LottoLocalDataService>>();
        service = new LottoLocalDataService(assemblyWrapper, logger);
    }

    [Fact]
    public async Task GetDrawsAsync_ReturnsEmpty_WhenJsonFileNotFound()
    {
        // Arrange
        assemblyWrapper.GetManifestResourceStream(Arg.Any<string>()).Returns((Stream)null);

        // Act
        var result = await service.GetDrawsAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetDrawsAsync_ReturnsEmpty_WhenJsonIsNotInCorrectFormat()
    {
        // Arrange
        var json = "{\"invalidProperty\": \"invalidValue\"}"; 
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        assemblyWrapper.GetManifestResourceStream(Arg.Any<string>()).Returns(stream);

        // Act
        var result = await service.GetDrawsAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetDrawsAsync_ReturnsEmpty_WhenJsonException()
    {
        // Arrange
        var invalidJson = "invalid json content";
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(invalidJson));
        assemblyWrapper.GetManifestResourceStream(Arg.Any<string>()).Returns(stream);

        // Act
        var result = await service.GetDrawsAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetDrawsAsync_ReturnsEmpty_WhenValidJsonButNoDraws()
    {
        // Arrange
        var json = "{\"draws\": []}";
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        assemblyWrapper.GetManifestResourceStream(Arg.Any<string>()).Returns(stream);

        // Act
        var result = await service.GetDrawsAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetDrawsAsync_ReturnsListOfDraws_WhenJsonIsInCorrectFormat()
    {
        // Arrange
        var json = "{\"draws\": [{" +
            "\"id\": \"draw-1\"," +
            "\"drawDate\": \"2024-09-23\"," +
            "\"number1\": \"53\"," +
            "\"number2\": \"33\"," +
            "\"number3\": \"26\"," +
            "\"number4\": \"85\"," +
            "\"number5\": \"12\"," +
            "\"number6\": \"37\"," +
            "\"bonus-ball\": \"40\"," +
            "\"topPrize\": 6123542}]}";
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        assemblyWrapper.GetManifestResourceStream(Arg.Any<string>()).Returns(stream);

        // Act
        var result = await service.GetDrawsAsync();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal("draw-1", result.First().Id);
        Assert.Equal(new DateTime(2024,09,23), result.First().DrawDate);
        Assert.NotEmpty(result.First().Numbers);
        Assert.Equal("53", result.First().Numbers[0]);
        Assert.Equal("33", result.First().Numbers[1]);
        Assert.Equal("26", result.First().Numbers[2]);
        Assert.Equal("85", result.First().Numbers[3]);
        Assert.Equal("12", result.First().Numbers[4]);
        Assert.Equal("37", result.First().Numbers[5]);
        Assert.Equal("40", result.First().BonusBall);
        Assert.Equal(6123542, result.First().TopPrize);
    }
}