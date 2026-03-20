import java.util.Scanner;
import java.util.Random;

public class Main {
    public static void main(String[] args) {
        System.out.println("Розробник: Дзябенко О. С.");
        System.out.println("-------------------------");

        int rows = 3;
        int cols = 3;
        int[][] matrixA = new int[rows][cols];
        Random random = new Random();

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                matrixA[i][j] = random.nextInt(99) + 1;
            }
        }

        System.out.println("- матриця А;");
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {

                System.out.printf("%4d", matrixA[i][j]);
            }
            System.out.println();
        }
        System.out.println("-------------------------");

        Scanner scanner = new Scanner(System.in);
        
        System.out.print("Введіть номер рядка i (від 0 до 2): ");
        int i = scanner.nextInt();
        
        System.out.print("Введіть номер стовпця j (від 0 до 2): ");
        int j = scanner.nextInt();

        if (i >= 0 && i < rows && j >= 0 && j < cols) {
            System.out.println("- значення a_ij матриці А: " + matrixA[i][j]);
        } else {
            System.out.println("Помилка: введені індекси виходять за межі матриці (мають бути від 0 до 2).");
        }

        scanner.close();
    }
}