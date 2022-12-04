using Xunit;
using Y2022.D02;

namespace Y2022.Tests.D02;

public class EntryPointBTests: IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        var input = new[]
        {
            "A X", // rock & loss => scissors: 0 + 3 = 3
            "B Y", // paper & draw => paper: 3 + 2 = 5
            "C Z", // scissors & win => rock: 6 + 1 = 7
            "A Y", // rock & draw => rock: 3 + 1 = 4
            "B X", // paper & loss => rock: 1
            "C X", // scissors & loss => paper: 2
            "A Z", // rock & win => paper: 8
        };
        
        var result = EntryPointB.Solve(input);
        Assert.Equal("30" , result);
    }
}