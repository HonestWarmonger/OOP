import java.util.Random;
import java.util.Scanner;

class Point {
    double x;
    double y;

    Point(double x, double y) {
        this.x = x;
        this.y = y;
    }
}

class Trapezoid {
    Point a, b, c, d;

    public Trapezoid(Point a, Point b, Point c, Point d) {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
    }

    private double distance(Point p1, Point p2) {
        return Math.sqrt(Math.pow(p2.x - p1.x, 2) + Math.pow(p2.y - p1.y, 2));
    }

    public double getPerimeter() {
        return distance(a, b) + distance(b, c) + distance(c, d) + distance(d, a);
    }

    public int getKey() {
        return (int) Math.round(getPerimeter());
    }

    @Override
    public String toString() {
        return String.format(
                "A(%.1f; %.1f), B(%.1f; %.1f), C(%.1f; %.1f), D(%.1f; %.1f), P = %.2f",
                a.x, a.y, b.x, b.y, c.x, c.y, d.x, d.y, getPerimeter()
        );
    }

    public static Trapezoid generateRandom(Random random) {
        double x1 = random.nextInt(10);
        double y1 = random.nextInt(10);

        double x2 = x1 + 4 + random.nextInt(5);
        double y2 = y1;

        double x3 = x2 - 1 - random.nextInt(3);
        double y3 = y1 + 3 + random.nextInt(5);

        double x4 = x1 + 1 + random.nextInt(3);
        double y4 = y3;

        Point a = new Point(x1, y1);
        Point b = new Point(x2, y2);
        Point c = new Point(x3, y3);
        Point d = new Point(x4, y4);

        return new Trapezoid(a, b, c, d);
    }
}

class HashTable {
    private Trapezoid[] table;
    private int size;

    public HashTable(int size) {
        this.size = size;
        table = new Trapezoid[size];
    }

    private int hash(int key) {
        return key % size;
    }

    public boolean insert(Trapezoid trapezoid) {
        int key = trapezoid.getKey();
        int index = hash(key);

        for (int i = 0; i < size; i++) {
            int newIndex = (index + i) % size;

            if (table[newIndex] == null) {
                table[newIndex] = trapezoid;
                return true;
            }
        }

        return false;
    }

    public void printTable() {
        System.out.println("\nВміст хеш-таблиці:");
        for (int i = 0; i < size; i++) {
            if (table[i] == null) {
                System.out.printf("%2d -> порожньо%n", i);
            } else {
                System.out.printf("%2d -> ключ: %3d | %s%n",
                        i, table[i].getKey(), table[i].toString());
            }
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        System.out.print("Введіть розмір хеш-таблиці: ");
        int size = scanner.nextInt();

        HashTable hashTable = new HashTable(size);

        System.out.print("Введіть кількість трапецій: ");
        int n = scanner.nextInt();

        for (int i = 0; i < n; i++) {
            Trapezoid trapezoid = Trapezoid.generateRandom(random);
            boolean inserted = hashTable.insert(trapezoid);

            if (inserted) {
                System.out.println("Елемент додано: " + trapezoid);
            } else {
                System.out.println("Не вдалося додати елемент, таблиця заповнена.");
            }
        }

        hashTable.printTable();
    }
}