import java.util.HashSet;
import java.util.Objects;
import java.util.Random;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();
        HashSet<Point> points = new HashSet<>();

        System.out.print("Введіть коефіцієнт A: ");
        double a = scanner.nextDouble();
        System.out.print("Введіть коефіцієнт B: ");
        double b = scanner.nextDouble();
        System.out.print("Введіть коефіцієнт C: ");
        double c = scanner.nextDouble();

        while (points.size() < 20) {
            double x = Math.round((random.nextDouble() * 20 - 10) * 10.0) / 10.0;
            double y = Math.round((random.nextDouble() * 20 - 10) * 10.0) / 10.0;
            points.add(new Point(x, y));
        }

        Point closestPoint = null;
        Point furthestPoint = null;
        double minDistance = Double.MAX_VALUE;
        double maxDistance = -1;

        double denominator = Math.sqrt(a * a + b * b);

        System.out.println("\nСписок точок та їхні відстані до прямої:");
        for (Point p : points) {
            double distance = Math.abs(a * p.getX() + b * p.getY() + c) / denominator;
            System.out.printf("Точка: %s -> Відстань: %.4f%n", p, distance);

            if (distance < minDistance) {
                minDistance = distance;
                closestPoint = p;
            }
            if (distance > maxDistance) {
                maxDistance = distance;
                furthestPoint = p;
            }
        }

        System.out.println("\nРезультати аналізу:");
        System.out.printf("Найближча точка: %s, відстань: %.4f%n", closestPoint, minDistance);
        System.out.printf("Найвіддаленіша точка: %s, відстань: %.4f%n", furthestPoint, maxDistance);

        scanner.close();
    }
}

class Point {
    private final double x;
    private final double y;

    public Point(double x, double y) {
        this.x = x;
        this.y = y;
    }

    public double getX() {
        return x;
    }

    public double getY() {
        return y;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Point point = (Point) o;
        return Double.compare(point.x, x) == 0 && Double.compare(point.y, y) == 0;
    }

    @Override
    public int hashCode() {
        return Objects.hash(x, y);
    }

    @Override
    public String toString() {
        return "(" + x + "; " + y + ")";
    }
}