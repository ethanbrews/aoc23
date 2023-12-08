using System.Collections;

namespace AdventOfCode.Days;

[ChallengeName("Gear Ratios")]
public class Day03 : IDay
{
    public object SolvePartOne(string input)
    {
        var lines = input.Split('\n');
        var symbols = lines
            .SelectMany((line, i) => line.Select((c, j) => (c, i, j)))
            .Where(o => "%+-$=@#*/&".Contains(o.c))
            .Select(o => (o.i, o.j));
        return symbols
            .Select(s => SearchForSurroundingNumbers(s, lines))
            .SelectMany(ns => ns
                .Select(n => SearchForFirstDigit(n, lines))
                .Distinct())
            .Select(s => ReadIntAtPosition(lines[s.i], s.j))
            .Sum();
    }

    private static (int i, int j) SearchForFirstDigit((int i, int j) s, IReadOnlyList<string> lines)
    {
        var cursor = s.j;
        while (cursor > 0 && char.IsDigit(lines[s.i][cursor - 1]))
        {
            cursor--;
        }

        return (s.i, cursor);
    } 

    private static IEnumerable<(int, int)> SearchForSurroundingNumbers((int i, int j) s, IReadOnlyList<string> lines)
    {
        for (var c = 0; c < 9; c++)
        {
            var i = (c / 3)-1;
            var j = (c % 3)-1;
            if (s.i + i < 0 || s.i + i >= lines.Count || s.j + j < 0 || s.j + j >= lines[s.i + i].Length)
                continue;
            if (!char.IsDigit(lines[s.i + i][s.j + j])) continue;
            yield return (s.i + i, s.j + j);
        }
    }

    private static int ReadIntAtPosition(string line, int digitPosition) 
    {
        var length = 0;
        while (char.IsDigit(line[digitPosition + (length++) + 1])) { }
        return Convert.ToInt32(line[digitPosition..(digitPosition + length)]);
    }

    public object SolvePartTwo(string input)
    {
        var lines = input.Split('\n');
        var symbols = lines
            .SelectMany((line, i) => line.Select((c, j) => (c, i, j)))
            .Where(o => "%+-$=@#*/&".Contains(o.c))
            .Select(o => (o.i, o.j));
        return symbols
            .Select(s => SearchForSurroundingNumbers(s, lines))
            .Select(ns => ns
                .Select(n => SearchForFirstDigit(n, lines))
                .Distinct())
            .Where(ns => ns.Count() == 2)
            .Select(ss => ss
                .Select(s => ReadIntAtPosition(lines[s.i], s.j))
                .Aggregate(1, (acc, val) => acc * val))
            .Sum();
    }
}