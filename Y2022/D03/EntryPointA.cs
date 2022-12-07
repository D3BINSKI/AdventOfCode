using System.Text;

namespace Y2022.D03;

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
        var compartmentsA = input
            .Select(line => line
                .Substring(0, line.Length / 2)
                .ToCharArray())
            .ToArray();
        var compartmentsB = input
            .Select(line => line
                .Substring(line.Length/2, line.Length/2)
                .ToCharArray())
            .ToArray();
        
        var priorities = new List<int>();

        for (int i = 0; i < compartmentsA.Length; i++)
        {
            var compartmentA = compartmentsA[i];
            var compartmentB = compartmentsB[i];
            var errorTypes = compartmentA
                .Intersect(compartmentB)
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