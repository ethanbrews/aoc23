using System.CommandLine;
using AdventOfCode;

var rootCommand = new RootCommand("Advent of code!");
var dayArgument = new Argument<string>();
rootCommand.AddArgument(dayArgument);
rootCommand.SetHandler(SolutionRunner.RunSolutionAsync, dayArgument);
return await rootCommand.InvokeAsync(args);