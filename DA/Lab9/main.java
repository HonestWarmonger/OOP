import java.util.Scanner;
import java.math.BigInteger;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("=== Лабораторна робота 2.3 | Варіант 11 ===");
        
        System.out.print("Введіть кількість кімнат з вільним місцем (n, за умовою 14): ");
        int n = scanner.nextInt();

        System.out.print("Введіть кількість першокурсників для заселення (k): ");
        int k = scanner.nextInt();

        if (n < 0 || k < 0) {
            System.out.println("Помилка: Кількість кімнат або студентів не може бути від'ємною!");
            return;
        }

        if (k > n) {
            System.out.println("Помилка: Кількість студентів (k) не може перевищувати кількість вільних місць (n)!");
            return;
        }

        System.out.println("\n--- Результати розрахунку ---");

        if (k == n) {
            System.out.println("Тип вибірки: Перестановки без повторень (P_n)");
            System.out.println("Формула: P_" + n + " = " + n + "!");
            
            BigInteger result = factorial(n);
            System.out.println("Кількість способів розселення: " + result);
        } else {
            System.out.println("Тип вибірки: Розміщення без повторень (A_n^k)");
            System.out.println("Формула: A_" + n + "^" + k + " = " + n + "! / (" + n + " - " + k + ")!");
            
            BigInteger result = permutation(n, k);
            System.out.println("Кількість способів розселення: " + result);
        }

        scanner.close();
    }

    public static BigInteger factorial(int num) {
        BigInteger result = BigInteger.ONE;
        for (int i = 2; i <= num; i++) {
            result = result.multiply(BigInteger.valueOf(i));
        }
        return result;
    }

    public static BigInteger permutation(int n, int k) {
        BigInteger result = BigInteger.ONE;
        for (int i = n; i > n - k; i--) {
            result = result.multiply(BigInteger.valueOf(i));
        }
        return result;
    }
}