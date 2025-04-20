using System;
using System.Linq;
using System.Text;

namespace RowLib
{
    public abstract class Rows
    {
        protected string str;
        public Rows(string s) { str = s; }
        public abstract int GetLength();
        public abstract string Increase();
    }

    // дублювання кожного символу
    public class Numbers : Rows
    {
        public Numbers(string s) : base(s) { }
        public override int GetLength() => str.Length * 2;
        public override string Increase()
        {
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                sb.Append(c).Append(c);
            }
            return sb.ToString();
        }
    }

    // дублювання лише символу 'k'
    public class Symbols : Rows
    {
        public Symbols(string s) : base(s) { }
        public override int GetLength() => str.Length + str.Count(c => c == 'k');
        public override string Increase()
        {
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                sb.Append(c);
                if (c == 'k')
                    sb.Append('k');
            }
            return sb.ToString();
        }
    }
}