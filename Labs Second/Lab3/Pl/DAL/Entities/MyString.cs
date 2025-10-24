using System;

namespace DAL.Entities
{
    [Serializable]
    public class MyString
    {
        public string Value { get; set; } = "";
        public int Length => Value.Length;

        public MyString() { }
        public MyString(string v) => Value = v;

        public int FindSubstring(string sub) => Value.IndexOf(sub, StringComparison.OrdinalIgnoreCase);

        public void InsertSubstring(int pos, string sub)
        {
            if (pos < 0 || pos > Value.Length) pos = Value.Length;
            Value = Value.Insert(pos, sub);
        }

        public void ReplaceSubstring(string oldSub, string newSub)
            => Value = Value.Replace(oldSub, newSub);

        public override string ToString() => $"{Value} (len={Length})";
    }
}
