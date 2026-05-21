import java.util.Scanner;

public class Main {

    public static double f(double x) {
        return Math.sin(x) / Math.sqrt(x * x + 1);
    }

    public static double y(double x) {
        return x * x * x - 2 * x * x - 6 * x - 1;
    }

    public static double dy(double x) {
        return 3 * x * x - 4 * x - 6;
    }

    public static double rectangleMethod(double a, double b, double h) {
        double sum = 0;
        int n = (int) ((b - a) / h);
        for (int i = 0; i < n; i++) {
            sum += f(a + (i + 0.5) * h);
        }
        return sum * h;
    }

    public static double trapezoidMethod(double a, double b, double h) {
        double sum = 0.5 * (f(a) + f(b));
        int n = (int) ((b - a) / h);
        for (int i = 1; i < n; i++) {
            sum += f(a + i * h);
        }
        return sum * h;
    }

    public static double simpsonMethod(double a, double b, double h) {
        double sum = 0;
        int n = (int) ((b - a) / h);
        for (int i = 0; i < n; i++) {
            double xL = a + i * h;
            double xR = xL + h;
            sum += (h / 6.0) * (f(xL) + 4 * f((xL + xR) / 2.0) + f(xR));
        }
        return sum;
    }

    public static double bisectionMethod(double a, double b, double eps) {
        if (y(a) * y(b) >= 0) {
            return Double.NaN;
        }
        double c = a;
        while ((b - a) / 2.0 > eps) {
            c = (a + b) / 2.0;
            if (Math.abs(y(c)) < 1e-12) {
                break;
            }
            if (y(c) * y(a) < 0) {
                b = c;
            } else {
                a = c;
            }
        }
        return c;
    }

    public static double newtonMethod(double a, double b, double eps) {
        double x = (a + b) / 2.0;
        for (int i = 0; i < 100; i++) {
            double dyVal = dy(x);
            if (Math.abs(dyVal) < 1e-12) {
                break;
            }
            double xNext = x - y(x) / dyVal;
            if (Math.abs(xNext - x) < eps) {
                return xNext;
            }
            x = xNext;
        }
        return x;
    }

    public static double secantMethod(double a, double b, double eps) {
        double x0 = a;
        double x1 = b;
        if (y(x0) * y(x1) >= 0) {
            return Double.NaN;
        }
        for (int i = 0; i < 100; i++) {
            double denominator = y(x1) - y(x0);
            if (Math.abs(denominator) < 1e-12) {
                break;
            }
            double xNext = x1 - y(x1) * (x1 - x0) / denominator;
            if (Math.abs(xNext - x1) < eps) {
                return xNext;
            }
            x0 = x1;
            x1 = xNext;
        }
        return x1;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("=== Завдання 1: Числове інтегрування ===");
        System.out.print("Введіть початок інтервалу a (для вар. 11 це 3): ");
        double a1 = scanner.nextDouble();
        System.out.print("Введіть кінець інтервалу b (для вар. 11 це 8): ");
        double b1 = scanner.nextDouble();
        System.out.print("Введіть крок h (для вар. 11 це 1.0): ");
        double h1 = scanner.nextDouble();

        System.out.printf("Метод прямокутників: %.6f\n", rectangleMethod(a1, b1, h1));
        System.out.printf("Метод трапецій: %.6f\n", trapezoidMethod(a1, b1, h1));
        System.out.printf("Метод Сімпсона: %.6f\n", simpsonMethod(a1, b1, h1));

        System.out.println("\n=== Завдання 2: Знаходження коренів ===");
        System.out.print("Введіть початок інтервалу a: ");
        double a2 = scanner.nextDouble();
        System.out.print("Введіть кінець інтервалу b: ");
        double b2 = scanner.nextDouble();
        double eps = 1e-6;

        double rBis = bisectionMethod(a2, b2, eps);
        double rNew = newtonMethod(a2, b2, eps);
        double rSec = secantMethod(a2, b2, eps);

        if (Double.isNaN(rBis)) {
            System.out.println("Метод половинчастого ділення: корінь не знайдено на цьому проміжку");
        } else {
            System.out.printf("Метод половинчастого ділення: %.6f\n", rBis);
        }

        System.out.printf("Метод дотичних (Ньютона): %.6f\n", rNew);

        if (Double.isNaN(rSec)) {
            System.out.println("Метод хорд (січних): корінь не знайдено на цьому проміжку");
        } else {
            System.out.printf("Метод хорд (січних): %.6f\n", rSec);
        }

        scanner.close();
    }
}