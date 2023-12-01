using System.Diagnostics;

namespace AdventOfCode.Days;

[ChallengeName("Trebuchet?!")]
public class Day01 : IDay
{
    public object SolvePartOne(string input)
    {
        return input
            .Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(line => Convert.ToInt32($"{line.First(char.IsDigit)}{line.Last(char.IsDigit)}"))
            .Sum();
    }
    
    public object SolvePartTwo(string input)
    {
        return input
            .Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(line => Convert.ToInt32($"{line.First(char.IsDigit)}{line.Last(char.IsDigit)}"))
            .Sum();
    }

    private char? WordToDigit(string word) => word switch
    {
        "zero" => '0',
        "one" => '1',
        "two" => '2',
        "three" => '3',
        "four" => '4',
        "five" => '5',
        "six" => '6',
        "seven" => '7',
        "eight" => '8',
        "nine" => '9',
        _ => null
    };
}