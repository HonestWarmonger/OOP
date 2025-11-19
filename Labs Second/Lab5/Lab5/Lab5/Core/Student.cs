namespace StudentSystem.Core
{
    public class Student : Person
    {
        public int Course { get; set; }
        public string StudentTicketId { get; set; }

        public string Residence { get; set; }

        public override string Sleep()
        {
            if (Course >= 3)
            {
                return $"{LastName} {FirstName} (Курс {Course}) — досвідчений студент, тому вміє спати стоячи.";
            }
            else
            {
                return $"{LastName} {FirstName} (Курс {Course}) — ще новачок, спить тільки в ліжку.";
            }
        }
        public override string ToString()
        {
            string loc = string.IsNullOrEmpty(Residence) ? "Вдома" : $"Гуртожиток {Residence}";
            return $"[{StudentTicketId}] {LastName} {FirstName}, {Gender}, {Course} курс. Житло: {loc}";
        }
    }
}