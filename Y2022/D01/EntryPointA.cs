namespace Y2022.D01;

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

        var max = groups.Select(x => x.Sum()).Max();
        return max.ToString();
    }

    public static string[] ReadFile() => File.ReadAllLines(@"D:\Software\Projects\AdventOfCode-old\Y2022\D01\input.txt");
}