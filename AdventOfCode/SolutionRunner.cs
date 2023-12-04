using System.Reflection;

namespace AdventOfCode;

public static class SolutionRunner
{
    private static readonly Type[] SolutionTypes = Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => t.GetInterfaces().Contains(typeof(IDay)) && t.GetConstructor(Type.EmptyTypes) is not null)
        .ToArray();
    
    private static IDay FindSolutionByName(string query) => Activator.CreateInstance(
        SolutionTypes.First(d => d.Name == query || d.Name[3..] == query)
    ) as IDay ?? throw new ArgumentException("The query does not match any solutions.", nameof(query));

    public static async Task RunSolutionByNameAsync(string query) => await RunSolutionAsync(FindSolutionByName(query));

    private static string InputFileName(IDay day) => Path.Combine("Input", day.GetType().Name + ".txt");

    private static string ChallengeName(IDay day) =>
        (day.GetType().GetCustomAttribute(typeof(ChallengeNameAttribute)) as ChallengeNameAttribute)?.Name ?? "???";

    private static async Task RunSolutionAsync(IDay day)
    {
        Console.WriteLine($"Running {day.GetType().Name}: {ChallengeName(day)}");
        var inputText = await File.ReadAllTextAsync(InputFileName(day));
        try
        {
            Console.WriteLine("Part One: " + day.SolvePartOne(inputText));
            Console.WriteLine("Part Two: " + day.SolvePartTwo(inputText));
        }
        catch (NotImplementedException)
        {
        }
    }
}