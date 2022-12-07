namespace Y2022.D03;

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
        var compartments = input
            .Select(line => line
                .Substring(0, line.Length)
                .ToCharArray())
            .ToArray();
        
        var priorities = new List<int>();

        for (int i = 0; i < compartments.Length; i+=3)
        {
            var compartmentA = compartments[i];
            var compartmentB = compartments[i+1];
            var compartmentC = compartments[i+2];
            var errorTypes = compartmentA
                .Intersect(compartmentB)
                .Intersect(compartmentC)
                .ToArray();

            foreach (var type in errorTypes)
            {
                priorities.Add(((type <= 'Z')? char.ToLower(type) - 6 : char.ToUpper(type)) - 'A' + 1);
            }
        }

        return priorities.Sum().ToString();
    }

    public static string[] ReadFile() => File.ReadAllLines(
        @"D:\Software\Projects\AdventOfCode-old\Y2022\D03\input.txt");
}