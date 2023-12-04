using System.Text.RegularExpressions;

namespace AdventOfCode.Days;


[ChallengeName("Cube Conundrum")]
public class Day02 : IDay
{
    public object SolvePartOne(string input)
    {
        return (from line in input.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)) 
            let id = ConvertInt(Regex.Match(line, @"Game (?<id>\d+): .*").Groups["id"].Value) 
            let r = MatchColour(line, "red") 
            let g = MatchColour(line, "green") 
            let b = MatchColour(line, "blue") 
            where r <= 12 && g <= 13 && b <= 14 select id)
            .Sum();
    }
    
    public object SolvePartTwo(string input)
    {
        return (from line in input.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)) 
                let r = MatchColour(line, "red") 
                let g = MatchColour(line, "green") 
                let b = MatchColour(line, "blue") 
                select r*g*b)
            .Sum();
    }

    private static int MatchColour(string line, string colour) => 
        Regex.Matches(line, @"(?<value>\d+) " + colour).Select(m => ConvertInt(m.Groups["value"].Value)).Max();

    private static int ConvertInt(string s) => string.IsNullOrEmpty(s) ? 0 : Convert.ToInt32(s);
}