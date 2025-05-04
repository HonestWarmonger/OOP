using System.Text;

namespace TextLib;

public class Text : IWhitespaceCleaner
{
    private readonly List<Row> _rows = new();

    // --- IWhitespaceCleaner ---
    public string NormalizeSpaces(string s)
    {
        var sb = new StringBuilder();
        bool prevSpace = false;
        foreach (char ch in s)
        {
            if (char.IsWhiteSpace(ch))
            {
                if (!prevSpace) sb.Append(' ');
                prevSpace = true;
            }
            else
            {
                sb.Append(ch);
                prevSpace = false;
            }
        }
        return sb.ToString();
    }

    public string Trim(string s) => s.Trim();

    // --- керування рядками ---
    public void AddRow(Row r) => _rows.Add(r);
    public bool RemoveRow(int index)
    {
        if (index < 0 || index >= _rows.Count) return false;
        _rows.RemoveAt(index);
        return true;
    }
    public void Clear() => _rows.Clear();

    // --- статистика ---
    public int ShortestRowLength() =>
        _rows.Count == 0 ? 0 : _rows.Min(r => r.Length);

    public double ConsonantPercentage()
    {
        int total = 0, consonants = 0;
        foreach (var r in _rows)
        {
            string s = r.Data;
            total += s.Count(char.IsLetter);
            consonants += Row.CountConsonants(s);
        }
        return total == 0 ? 0 : 100.0 * consonants / total;
    }
}