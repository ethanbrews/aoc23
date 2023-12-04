namespace AdventOfCode.Days;

[ChallengeName("Gear Ratios")]
public class Day03 : IDay
{
    public object SolvePartOne(string input)
    {
        var lines = input.Split('\n');
        var symbols = lines
            .SelectMany((line, i) => line.Select((c, j) => (c, i, j)))
            .Where(o => "*/%+=.$".Contains(o.c))
            .Select(o => (o.i, o.j))
            .ToList();

        foreach (var s in symbols)
        {
            //if (char.IsDigit(lines[s.i][s.j]))
        }

        return 0;
    }

    public object SolvePartTwo(string input)
    {
        throw new NotImplementedException();
    }
}