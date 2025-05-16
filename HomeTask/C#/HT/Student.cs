using System;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }

    public Student(string firstName, string lastName, string patronymic)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName} {Patronymic}";
    }
}
