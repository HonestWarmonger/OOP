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

    Trapezoid(Point a, Point b, Point c, Point d) {
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

    public static Trapezoid generateRandom(Random random) {
        double x1 = random.nextInt(10);
        double y1 = random.nextInt(10);

        double x2 = x1 + 4 + random.nextInt(5);
        double y2 = y1;

        double x3 = x2 - 1 - random.nextInt(3);
        double y3 = y1 + 3 + random.nextInt(5);

        double x4 = x1 + 1 + random.nextInt(3);
        double y4 = y3;

        return new Trapezoid(
                new Point(x1, y1),
                new Point(x2, y2),
                new Point(x3, y3),
                new Point(x4, y4)
        );
    }

    @Override
    public String toString() {
        return String.format(
                "A(%.1f; %.1f), B(%.1f; %.1f), C(%.1f; %.1f), D(%.1f; %.1f), P = %.2f",
                a.x, a.y, b.x, b.y, c.x, c.y, d.x, d.y, getPerimeter()
        );
    }
}

class HashTableLevel1 {
    private Trapezoid[] table;
    private int size;

    HashTableLevel1(int size) {
        this.size = size;
        table = new Trapezoid[size];
    }

    private int hash(int key) {
        return key % size;
    }

    public boolean insert(Trapezoid trapezoid) {
        int key = trapezoid.getKey();
        int index = hash(key);

        if (table[index] == null) {
            table[index] = trapezoid;
            return true;
        } else {
            return false;
        }
    }

    public void printTable() {
        System.out.println("\nХеш-таблиця першого рівня:");
        for (int i = 0; i < size; i++) {
            if (table[i] == null) {
                System.out.printf("%2d -> порожньо%n", i);
            } else {
                System.out.printf("%2d -> ключ: %3d | %s%n",
                        i, table[i].getKey(), table[i]);
            }
        }
    }
}

class HashTableLevel2 {
    private Trapezoid[] table;
    private int size;

    HashTableLevel2(int size) {
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
        System.out.println("\nХеш-таблиця другого рівня:");
        for (int i = 0; i < size; i++) {
            if (table[i] == null) {
                System.out.printf("%2d -> порожньо%n", i);
            } else {
                System.out.printf("%2d -> ключ: %3d | %s%n",
                        i, table[i].getKey(), table[i]);
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

        System.out.print("Введіть кількість елементів: ");
        int count = scanner.nextInt();

        if (count > size) {
            System.out.println("Кількість елементів не може бути більшою за розмір таблиці.");
            return;
        }
        HashTableLevel1 table1 = new HashTableLevel1(size);
        HashTableLevel2 table2 = new HashTableLevel2(size);

        System.out.println("\n--- Завдання першого рівня ---");
        System.out.println("Додавання елементів без урахування колізій:");

        int added = 0;
        int attempts = 0;

        while (added < count && attempts < 1000) {
            Trapezoid trapezoid = Trapezoid.generateRandom(random);

            if (table1.insert(trapezoid)) {
                System.out.println("Додано: " + trapezoid);
                added++;
            }

            attempts++;
        }

        if (added < count) {
            System.out.println("Не вдалося додати всі елементи без колізій.");
        }

        table1.printTable();

        System.out.println("\n--- Завдання другого рівня ---");
        System.out.println("Додавання елементів з урахуванням колізій:");

        for (int i = 0; i < count; i++) {
            Trapezoid trapezoid = Trapezoid.generateRandom(random);

            if (table2.insert(trapezoid)) {
                System.out.println("Додано: " + trapezoid);
            } else {
                System.out.println("Елемент не додано, таблиця заповнена.");
            }
        }

        table2.printTable();
    }
}