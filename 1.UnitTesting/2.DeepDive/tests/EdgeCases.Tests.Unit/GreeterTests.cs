using FluentAssertions;
using NSubstitute;
using Xunit;

namespace EdgeCases.Tests.Unit;

public class GreeterTests
{
    private readonly IClock _clock = Substitute.For<IClock>();
    private readonly Greeter _sut;

    public GreeterTests()
    {
        _sut = new Greeter(_clock);
    }
    
    [Fact]
    public void GenerateGreetText_ShouldReturnGoodMorning_WhenItsMorning()
    {
        // Arrange
        _clock.Now.Returns(new DateTime(2023, 12, 4, 9, 0, 0));

        // Act
        var result = _sut.GenerateGreetText();

        // Assert
        result.Should().Be("Good morning");
    }
    
    [Fact]
    public void GenerateGreetText_ShouldReturnGoodAfternoon_WhenItsAfternoon()
    {
        // Arrange
        _clock.Now.Returns(new DateTime(2023, 12, 4, 15, 0, 0));

        // Act
        var result = _sut.GenerateGreetText();

        // Assert
        result.Should().Be("Good afternoon");
    }
    
    [Fact]
    public void GenerateGreetText_ShouldReturnGoodEvening_WhenItsEvening()
    {
        // Arrange
        _clock.Now.Returns(new DateTime(2023, 12, 4, 20, 0, 0));

        // Act
        var result = _sut.GenerateGreetText();

        // Assert
        result.Should().Be("Good evening");
    }
}
