namespace Y2022.D02;

public class EntryPointA: IEntryPoint
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
            .Select(parts => new Round(
                (Choice)Enum.Parse(typeof(Choice), parts[0]), 
                (Choice)Enum.Parse(typeof(Choice), parts[1])))
            .ToArray();

        var finalResult = rounds
            .Select(round => round.GetResult())
            .Sum();

        return finalResult.ToString();
    }

    public static string[] ReadFile()
    {
        return File.ReadAllLines(@"D:\Software\Projects\AdventOfCode-old\Y2022\D02\input.txt");
    }
}

public class Round
{
    private readonly Choice _opponentChoice;

    private readonly Choice _myChoice;

    public Round(Choice opponentChoice, Choice myChoice)
    {
        _opponentChoice = opponentChoice;
        _myChoice = myChoice;
    }

    public int GetResult()
    {
        var figurePoints = (int)_myChoice;
        if (_opponentChoice == _myChoice)
        {
            return figurePoints + (int)Result.Draw;
        }

        switch (_opponentChoice)
        {
            case Choice.Rock when _myChoice is Choice.Paper:
            case Choice.Paper when _myChoice == Choice.Scissors:
            case Choice.Scissors when _myChoice == Choice.Rock:
                return figurePoints + (int)Result.Win;
            default:
                return figurePoints + (int)Result.Loss;
        }
    }
}