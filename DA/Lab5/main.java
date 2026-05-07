public class Main {


    static class Student {
        String lastName;
        String firstName;
        int course;
        boolean isMale;
        boolean livesInHostel;
        String group;

        public Student(String lastName, String firstName, int course, boolean isMale, boolean livesInHostel, String group) {
            this.lastName = lastName;
            this.firstName = firstName;
            this.course = course;
            this.isMale = isMale;
            this.livesInHostel = livesInHostel;
            this.group = group;
        }

        @Override
        public String toString() {
            return String.format("%-12s %-8s | Курс: %d | Стать: %-4s | Гуртожиток: %-3s | Група: %s",
                    lastName, firstName, course, 
                    (isMale ? "Male" : "Fem "), 
                    (livesInHostel ? "Yes" : "No "), 
                    group);
        }
    }

    public static int sequentialSearch(Student[] arr, int startIndex) {
        for (int i = startIndex; i < arr.length; i++) {
            if (arr[i].course == 6 && arr[i].isMale && arr[i].livesInHostel) {
                return i; 
            }
        }
        return -1; 
    }

    public static Student[] removeTargetStudents(Student[] arr) {
        int index;
        while ((index = sequentialSearch(arr, 0)) != -1) {
            Student[] newArr = new Student[arr.length - 1];
            System.arraycopy(arr, 0, newArr, 0, index);
            System.arraycopy(arr, index + 1, newArr, index, arr.length - index - 1);
            arr = newArr;
        }
        return arr;
    }


    static class BSTNode {
        Student data;
        BSTNode left, right;

        public BSTNode(Student data) {
            this.data = data;
            left = right = null;
        }
    }

    static class BST {
        BSTNode root;

        public void insertRoot(Student student) {
            root = insertRootRec(root, student);
        }

        private BSTNode insertRootRec(BSTNode node, Student student) {
            if (node == null) {
                return new BSTNode(student);
            }
            
            if (student.group.compareTo(node.data.group) < 0) {
                node.left = insertRootRec(node.left, student);
                node = rotateRight(node); 
            } else {
                node.right = insertRootRec(node.right, student);
                node = rotateLeft(node);  
            }
            return node;
        }

        public BSTNode rotateRight(BSTNode y) {
            if (y == null || y.left == null) return y;
            BSTNode x = y.left;
            BSTNode T2 = x.right;
            x.right = y;
            y.left = T2;
            return x;
        }

        public BSTNode rotateLeft(BSTNode x) {
            if (x == null || x.right == null) return x;
            BSTNode y = x.right;
            BSTNode T2 = y.left;
            y.left = x;
            x.right = T2;
            return y;
        }

        public Student search(String group) {
            BSTNode res = searchRec(root, group);
            return res != null ? res.data : null;
        }

        private BSTNode searchRec(BSTNode root, String group) {
            if (root == null || root.data.group.equals(group)) {
                return root;
            }
            if (root.data.group.compareTo(group) > 0) {
                return searchRec(root.left, group);
            }
            return searchRec(root.right, group);
        }

        public void printLine() {
            printDescendingRec(root);
        }

        private void printDescendingRec(BSTNode node) {
            if (node != null) {
                printDescendingRec(node.right);
                System.out.print(node.data.lastName + "(" + node.data.group + ") ");
                printDescendingRec(node.left);
            }
        }
    }


    public static void main(String[] args) {
        
        System.out.println("====== ЗАВДАННЯ ПЕРШОГО РІВНЯ ======");

        Student[] studentsArray = {
            new Student("Petrenko", "Andriy", 3, true, false, "KN-21"),
            new Student("Kovalchuk", "Anna", 2, false, true, "PZ-22"),
            new Student("Sydorenko", "Oleh", 6, true, true, "KI-23"),
            new Student("Grytsenko", "Iryna", 4, false, false, "SA-24"),
            new Student("Kravchenko", "Maksym", 1, true, true, "KN-25"),
            new Student("Savchenko", "Yuliia", 5, false, true, "KN-21"),
            new Student("Rudenko", "Ivan", 6, true, true, "PZ-22"),
            new Student("Danylenko", "Olena", 3, false, false, "KI-23")
        };

        System.out.println("Початковий масив студентів:");
        for (Student s : studentsArray) System.out.println(s);

        studentsArray = removeTargetStudents(studentsArray);

        System.out.println("\nМасив ПІСЛЯ виконання завдання (видалено чоловіків 6 курсу з гуртожитку):");
        for (Student s : studentsArray) System.out.println(s);


        System.out.println("\n=== Другий рівень ===");
        System.out.println("Створення BST-дерева з вставкою в корінь:\n");
        
        BST tree = new BST();
        
        for (Student s : studentsArray) {
            tree.insertRoot(s);
            System.out.print("Після додавання " + s.lastName + ": ");
            tree.printLine();
            System.out.println();
        }

        if (studentsArray.length > 0) {
            String searchKey = studentsArray[studentsArray.length - 1].group; 
            System.out.println("\nПошук в BST-дереві за групою: " + searchKey);
            Student foundStudent = tree.search(searchKey);
            
            System.out.println("Знайдений вузол:");
            if (foundStudent != null) {
                System.out.println(foundStudent);
            } else {
                System.out.println("Не знайдено.");
            }
        }
    }
}