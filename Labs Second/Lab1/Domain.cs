using System;

namespace Lab31V11.Domain
{
    public enum Gender { Unknown = 0, Male = 1, Female = 2 }

    public abstract class Person
    {
        public string FirstName;
        public string LastName;

        protected Person(string first, string last)
        {
            if (string.IsNullOrWhiteSpace(first)) throw new ArgumentException("FirstName is required");
            if (string.IsNullOrWhiteSpace(last)) throw new ArgumentException("LastName is required");
            FirstName = first.Trim();
            LastName = last.Trim();
        }

        public string FullName => $"{FirstName} {LastName}";
    }

    // додаткова “вмiлiсть” з варiанта
    public interface ISleepStanding { void SleepStanding(); }

    public sealed class Student : Person, ISleepStanding
    {
        // обов’язковi
        public string StudentId;
        public int Course;
        public Gender Gender;

        // проживання
        public bool LivesInDorm;
        public int DormNumber;      // якщо в гуртожитку
        public string DormRoom;     // кiмната
        public string City;         // iнакше

        public Student(string first, string last, string id, int course, Gender gender)
            : base(first, last)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("StudentId is required");
            if (course < 1 || course > 6) throw new ArgumentException("Course must be 1..6");
            StudentId = id.Trim();
            Course = course;
            Gender = gender;
        }

        public void SetDorm(int dormNo, string room)
        {
            LivesInDorm = true;
            DormNumber = dormNo;
            DormRoom = room ?? "";
            City = null;
        }

        public void SetCity(string city)
        {
            LivesInDorm = false;
            City = city ?? "";
            DormNumber = 0;
            DormRoom = null;
        }

        public void SleepStanding() { }
    }

    // Двi пов'язанi сутностi за табл. варiанта Seller, Gardener
    public sealed class Seller : Person
    {
        public string Shop;
        public Seller(string first, string last, string shop = null) : base(first, last) { Shop = shop ?? ""; }
    }

    public sealed class Gardener : Person
    {
        public string Area;
        public Gardener(string first, string last, string area = null) : base(first, last) { Area = area ?? ""; }
    }
}
