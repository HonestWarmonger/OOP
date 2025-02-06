namespace DigitStringApp
{
    public class DigitString
    {
        private string value; // поле для зберігання рядка

        // Конструктор з початковим рядком
        public DigitString(string str)
        {
            value = str;
        }

        // Метод обчислення довжини рядка
        public int GetLength()
        {
            return value.Length;
        }

        // Метод видалення 5
        public void RemoveChar5()
        {
            value = value.Replace("5", "");
        }

        // Гетер
        public string GetValue()
        {
            return value;
        }

        // Сетер
        public void SetValue(string newVal)
        {
            value = newVal;
        }
    }
}
