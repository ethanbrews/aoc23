using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days;

[ChallengeName("Trebuchet?!")]
public partial class Day01 : IDay
{
    public object SolvePartOne(string input) => Solve(input, @"\d");

    public object SolvePartTwo(string input) => Solve(input, @"\d|zero|one|two|three|four|five|six|seven|eight|nine");

    private static int Solve(string input, string pattern) =>
        input
            .Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(line => WordToNumber(Regex.Match(line, pattern).Value) * 10 + WordToNumber(Regex.Match(line, pattern, RegexOptions.RightToLeft).Value))
            .Sum();

    private static int WordToNumber(string word) => word switch
    {
        "zero" or "0" => 0,
        "one" or "1" => 1,
        "two" or "2" => 2,
        "three" or "3" => 3,
        "four" or "4" => 4,
        "five" or "5" => 5,
        "six" or "6" => 6,
        "seven" or "7" => 7,
        "eight" or "8" => 8,
        "nine" or "9" => 9,
        _ => throw new ArgumentException("Invalid 0-9 number", nameof(word))
    };
    
}