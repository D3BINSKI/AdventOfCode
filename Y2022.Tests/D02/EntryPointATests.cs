using Xunit;
using Y2022.D02;

namespace Y2022.Tests.D02;

public class EntryPointATests: IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        var input = new[]
        {
            "A X", // rock-rock = draw 4 point
            "B Y", // paper-paper = draw 5 points
            "C Z", // scissors-scissors = draw 6 points
            "A Y", // rock-paper = win 8 points
            "B X", // paper-rock = loss 1 points
            "C X", // scissors-rock = loss 7 points
            "A Z", // rock-scissors = loss 3 points
        };
        
        var result = EntryPointA.Solve(input);
        Assert.Equal("34", result);
    }
}
