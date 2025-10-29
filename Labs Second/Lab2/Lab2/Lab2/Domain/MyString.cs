using System;

namespace Lab32_Var11.Domain
{
    public class MyString : IComparable<MyString>
    {
        public string Value { get; set; }
        public int Length => Value.Length;

        public MyString(string value) => Value = value;

        public bool Contains(string sub) => Value.Contains(sub);
        public void Insert(int index, string sub) => Value = Value.Insert(index, sub);
        public void Replace(string oldSub, string newSub) => Value = Value.Replace(oldSub, newSub);

        public override string ToString() => $"{Value} (len={Length})";

        public int CompareTo(MyString other)
        {
            if (other == null) return 1;
            return Length.CompareTo(other.Length);
        }
    }
}

