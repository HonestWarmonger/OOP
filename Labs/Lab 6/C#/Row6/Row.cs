namespace TextLib;

public class Row
{
    private string _data;
    public Row(string text = "") => _data = text;
    public string Data => _data;          // ���� �������
    public int Length => _data.Length;

    public static int CountConsonants(string s)
    {
        const string vowels = "aeiou�������AEIOU�ŪȲ����";
        return s.Count(ch => char.IsLetter(ch) && !vowels.Contains(ch));
    }
}