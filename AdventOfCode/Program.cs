using System.CommandLine;
using AdventOfCode;

var rootCommand = new RootCommand("Advent of code!");
var dayArgument = new Argument<string>();
rootCommand.AddArgument(dayArgument);
rootCommand.SetHandler(RunByNameAsync, dayArgument);
return await rootCommand.InvokeAsync(args);

async Task RunByNameAsync(string name)
{
    if (name == "today")
        name = $"Day{DateTime.Now.Date.Day:D2}";
    await SolutionRunner.RunSolutionByNameAsync(name);
}