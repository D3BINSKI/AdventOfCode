// See https://aka.ms/new-console-template for more information

using CalorieCounting01;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines(@"D:\Software\Projects\AdventOfCode\CalorieCounting01\data\Calories.dat");

// var calories = lines.GroupBy();
var elves = new List<Elf>();
var provisions = new List<Provision>();


foreach (var line in lines)
{

    if (line == "")
    {
        elves.Add(new Elf(provisions));
        provisions = new List<Provision>();
        continue;
    }

    if(line == lines[^1])
    {
        provisions.Add(new Provision(int.Parse(line)));
        elves.Add(new Elf(provisions));
        continue;
    }
    provisions.Add(new Provision(int.Parse(line)));
}

var top3Backpacks = elves.Select(elf => elf.Provisions
        .Sum(provision => provision.Calories))
    .OrderByDescending(calories => calories)
    .Take(3)
    .ToArray();

foreach (var backpack in top3Backpacks)
{
    Console.WriteLine(backpack);
}

Console.WriteLine($"Sum of calories in top 3 backpacks: {top3Backpacks.Sum()}");