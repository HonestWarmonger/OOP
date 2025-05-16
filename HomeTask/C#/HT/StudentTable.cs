using System;

public class StudentTable
{
    private Student[] students;

    public StudentTable(int count)
    {
        students = new Student[count];
    }

    // Властивість для доступу до кількості студентів
    public int Count
    {
        get { return students.Length; }
    }

    // Індексатор для доступу до студентів
    public Student this[int index]
    {
        get
        {
            if (index < 0 || index >= students.Length)
                throw new IndexOutOfRangeException("Неправильний індекс!");
            return students[index];
        }
        set
        {
            if (index < 0 || index >= students.Length)
                throw new IndexOutOfRangeException("Неправильний індекс!");
            students[index] = value;
        }
    }
}
