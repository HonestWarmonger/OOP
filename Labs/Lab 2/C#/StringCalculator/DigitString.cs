using System;

namespace DigitStringLib
{
    public class DigitString
    {
        private string value;

        //Конструктор за замовчуванням
        public DigitString()
        {
            value = "";
        }

        //Конструктор з параметром
        public DigitString(string initialValue)
        {
            value = initialValue;
        }

        //Конструктор копіювання
        public DigitString(DigitString other)
        {
            this.value = other.value;
        }

        //Фіналізатор
        ~DigitString()
        {

        }

        public int GetLength()
        {
            return value.Length;
        }


        public void RemoveChar5()
        {
            value = value.Replace("5", "");
        }

        public string GetValue()
        {
            return value;
        }
    }
}