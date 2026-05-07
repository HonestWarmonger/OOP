import java.util.Scanner;


class Student {
    String lastName;
    String firstName;
    String group;
    String gender;

    public Student(String lastName, String firstName, String group, String gender) {
        this.lastName = lastName;
        this.firstName = firstName;
        this.group = group;
        this.gender = gender;
    }

    @Override
    public String toString() {
        return String.format("%-12s %-12s | Група: %-5s | Стать: %s", 
                lastName, firstName, group, gender);
    }
}

class Node {
    Student data;
    Node next;

    public Node(Student data) {
        this.data = data;
        this.next = null;
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println("=== ПЕРШИЙ РІВЕНЬ: МАСИВ ===");
        Student[] studentsArray = {
            new Student("Іванов", "Олексій", "КН-21", "Чол"),
            new Student("Петрова", "Анна", "КН-22", "Жін"),
            new Student("Сидоров", "Борис", "КН-21", "Чол"),
            new Student("Бондар", "Дмитро", "КН-22", "Чол"),
            new Student("Шевченко", "Вікторія", "КН-21", "Жін")
        };

        System.out.println("Перед сортуванням:");
        printArray(studentsArray);

        selectionSortArray(studentsArray);

        System.out.println("\nПісля сортування вибіркою (за ім'ям):");
        printArray(studentsArray);


        System.out.println("\n\n=== ДРУГИЙ РІВЕНЬ: ОДНОСПРЯМОВАНИЙ СПИСОК ===");
        Node head = createLinkedList(studentsArray);

        System.out.println("Перед сортуванням списку:");
        printList(head);

        head = selectionSortList(head);

        System.out.println("\nПісля сортування вибіркою (за ім'ям):");
        printList(head);
    }

    public static void selectionSortArray(Student[] arr) {
        for (int i = 0; i < arr.length - 1; i++) {
            int minIdx = i;
            for (int j = i + 1; j < arr.length; j++) {
                if (arr[j].firstName.compareToIgnoreCase(arr[minIdx].firstName) < 0) {
                    minIdx = j;
                }
            }
            Student temp = arr[minIdx];
            arr[minIdx] = arr[i];
            arr[i] = temp;
        }
    }

    public static void printArray(Student[] arr) {
        for (Student s : arr) System.out.println(s);
    }

    public static Node createLinkedList(Student[] arr) {
        if (arr.length == 0) return null;
        Node head = new Node(arr[0]);
        Node current = head;
        for (int i = 1; i < arr.length; i++) {
            current.next = new Node(arr[i]);
            current = current.next;
        }
        return head;
    }

    public static Node selectionSortList(Node head) {
        for (Node i = head; i != null; i = i.next) {
            Node minNode = i;
            for (Node j = i.next; j != null; j = j.next) {
                if (j.data.firstName.compareToIgnoreCase(minNode.data.firstName) < 0) {
                    minNode = j;
                }
            }
            Student temp = i.data;
            i.data = minNode.data;
            minNode.data = temp;
        }
        return head;
    }

    public static void printList(Node head) {
        Node current = head;
        while (current != null) {
            System.out.println(current.data);
            current = current.next;
        }
    }
}