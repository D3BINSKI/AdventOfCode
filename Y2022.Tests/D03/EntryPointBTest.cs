using Xunit;
using Y2022.D03;

namespace Y2022.Tests.D03;

public class EntryPointBTest: IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        var group1 = new[]
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg"
        };
        
        var group2 = new[]
        {
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };
        
        var allGroups = new[] {group1, group2}.SelectMany(group => group).ToArray();
        
        Assert.Equal("18", EntryPointB.Solve(group1));
        Assert.Equal("52", EntryPointB.Solve(group2));
        Assert.Equal("70", EntryPointB.Solve(allGroups));
    }
}