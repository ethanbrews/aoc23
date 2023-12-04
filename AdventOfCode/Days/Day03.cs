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
            .Select(o => (o.i, o.j))
            .ToList();

        var total = 0;
        foreach (var s in symbols)
        {
            for (var c = 0; c < 9; c++)
            {
                var i = (c / 3)-1;
                var j = (c % 3)-1;
                if (s.i + i < 0 || s.i + i >= lines.Length || s.j + j < 0 || s.j + j >= lines[s.i + i].Length)
                    continue;
                if (!char.IsDigit(lines[s.i + i][s.j + j])) continue;
                total += ReadIntAtPosition(lines[s.i + i], s.j + j);
                break;
            }
        }

        return total;
    }

    private static int ReadIntAtPosition(string line, int digitPosition)
    {
        var cursor = digitPosition;
        while (cursor > 0 && char.IsDigit(line[cursor - 1]))
        {
            cursor--;
        }

        var length = 0;
        while (char.IsDigit(line[cursor + (length++) + 1]))
        {
        }
        //Console.WriteLine($"{line[..cursor]}[{line[cursor..(cursor + length)]}]{line[(cursor+length)..]}");
        return Convert.ToInt32(line[cursor..(cursor + length)]);
    }

    public object SolvePartTwo(string input)
    {
        throw new NotImplementedException();
    }
}