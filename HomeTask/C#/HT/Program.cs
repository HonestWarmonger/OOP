using System;

class Program
{
    static void Main()
    {
        // ��������� ������� � 3 ��������
        StudentTable table = new StudentTable(3);

        // ������ �������� ����� ����������
        table[0] = new Student("�����", "��������", "����������");
        table[1] = new Student("����", "��������", "��������");
        table[2] = new Student("�����", "��������", "���㳿���");

        // �������� ��� ��������
        for (int i = 0; i < table.Count; i++)
        {
            Console.WriteLine($"������� {i + 1}: {table[i]}");
        }

        // �������� ������� ��������
        Console.WriteLine($"ʳ������ �������� � �������: {table.Count}");
    }
}
