namespace Y2022.D02;

public class EntryPointB: IEntryPoint
{
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    public static string Solve(string[] input)
    {  
        var rounds = input
            .Select(line => line.Split(' '))
            .Select(parts => new RoundImproved(
                (Choice)Enum.Parse(typeof(Choice), parts[0]), 
                (Result)Enum.Parse(typeof(Result), parts[1])))
            .ToArray();

        var finalResult = rounds
            .Select(round => round.GetResult())
            .Sum();

        return finalResult.ToString();
    }

    public static string[] ReadFile() => File.ReadAllLines(@"D:\Software\Projects\AdventOfCode-old\Y2022\D02\input.txt");
}

public class RoundImproved
{
    private readonly Choice _opponentChoice;

    private readonly Result _result;

    public RoundImproved(Choice opponentChoice, Result result)
    {
        _opponentChoice = opponentChoice;
        _result = result;
    }

    public int GetResult()
    {
        var resultPoints = (int)_result;
        return _opponentChoice switch
        {
            Choice.Rock when _result == Result.Win => resultPoints + (int)Choice.Paper,
            Choice.Rock when _result == Result.Loss => resultPoints + (int)Choice.Scissors,
            Choice.Rock when _result == Result.Draw => resultPoints + (int)Choice.Rock,
            Choice.Paper when _result == Result.Win => resultPoints + (int)Choice.Scissors,
            Choice.Paper when _result == Result.Loss => resultPoints + (int)Choice.Rock,
            Choice.Paper when _result == Result.Draw => resultPoints + (int)Choice.Paper,
            Choice.Scissors when _result == Result.Win => resultPoints + (int)Choice.Rock,
            Choice.Scissors when _result == Result.Loss => resultPoints + (int)Choice.Paper,
            Choice.Scissors when _result == Result.Draw => resultPoints + (int)Choice.Scissors,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}