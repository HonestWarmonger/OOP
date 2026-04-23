class Student {
    String surname;
    int course;
    int studentId;
    double averageGrade;
    String citizenship;

    public Student(String surname, int course, int studentId, double averageGrade, String citizenship) {
        this.surname = surname;
        this.course = course;
        this.studentId = studentId;
        this.averageGrade = averageGrade;
        this.citizenship = citizenship;
    }

    public boolean isExcellent() {
        return averageGrade >= 90;
    }

    public boolean isForeignFirstYearExcellent() {
        return course == 1
                && !citizenship.equalsIgnoreCase("Україна")
                && isExcellent();
    }

    @Override
    public String toString() {
        return String.format("%-12s %-6d %-15d %-12.1f %-15s",
                surname, course, studentId, averageGrade, citizenship);
    }
}

class TreeNode {
    Student data;
    TreeNode left;
    TreeNode right;

    public TreeNode(Student data) {
        this.data = data;
    }
}

class BinaryTree {
    private TreeNode root;

    public void insert(Student student) {
        root = insertRec(root, student);
    }

    private TreeNode insertRec(TreeNode node, Student student) {
        if (node == null) {
            return new TreeNode(student);
        }

        if (student.studentId < node.data.studentId) {
            node.left = insertRec(node.left, student);
        } else if (student.studentId > node.data.studentId) {
            node.right = insertRec(node.right, student);
        } else {
            System.out.println("Студент з таким номером квитка вже існує: " + student.studentId);
        }

        return node;
    }

    public void printInOrder() {
        if (root == null) {
            System.out.println("Дерево порожнє.");
            return;
        }

        System.out.printf("%-12s %-6s %-15s %-12s %-15s%n",
                "Прізвище", "Курс", "Студ. квиток", "Сер. бал", "Громадянство");
        System.out.println("---------------------------------------------------------------");
        printInOrderRec(root);
    }

    private void printInOrderRec(TreeNode node) {
        if (node != null) {
            printInOrderRec(node.left);
            System.out.println(node.data);
            printInOrderRec(node.right);
        }
    }

    public void searchForeignFirstYearExcellent() {
        System.out.println("\nРезультати пошуку:");
        System.out.printf("%-12s %-6s %-15s %-12s %-15s%n",
                "Прізвище", "Курс", "Студ. квиток", "Сер. бал", "Громадянство");
        System.out.println("---------------------------------------------------------------");

        boolean[] found = {false};
        searchRec(root, found);

        if (!found[0]) {
            System.out.println("Студентів за заданим критерієм не знайдено.");
        }
    }

    private void searchRec(TreeNode node, boolean[] found) {
        if (node != null) {
            searchRec(node.left, found);

            if (node.data.isForeignFirstYearExcellent()) {
                System.out.println(node.data);
                found[0] = true;
            }

            searchRec(node.right, found);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        BinaryTree tree = new BinaryTree();

        tree.insert(new Student("Іваненко", 2, 1005, 84, "Україна"));
        tree.insert(new Student("Петренко", 1, 1002, 95, "Польща"));
        tree.insert(new Student("Сидоренко", 3, 1010, 88, "Україна"));
        tree.insert(new Student("Khan", 1, 1001, 92, "Казахстан"));
        tree.insert(new Student("Smith", 1, 1007, 78, "США"));
        tree.insert(new Student("Aliyev", 1, 1003, 96, "Азербайджан"));
        tree.insert(new Student("Бондар", 4, 1012, 91, "Україна"));

        System.out.println("Вміст дерева (послідовний обхід):");
        tree.printInOrder();

        tree.searchForeignFirstYearExcellent();
    }
}