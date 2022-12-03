namespace Y2022.D01;

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
        var groups = new List<List<int>>();
        var rowNumber = 0;
        while (rowNumber < input.Length)
        {
            var group = input
                .Skip(rowNumber)
                .TakeWhile(x => x != string.Empty)
                .Select(int.Parse)
                .ToList();
            groups.Add(group);
            rowNumber += group.Count + 1;
        }

        var top3Sum = groups.Select(x => x.Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
        return top3Sum.ToString();
    }

    public static string[] ReadFile() => File.ReadAllLines(@"D:\Software\Projects\AdventOfCode-old\Y2022\D01\input.txt");
}