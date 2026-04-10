import java.util.InputMismatchException;
import java.util.Scanner;
import java.time.Year;

class Bus {
    private String driverName;
    private String busNumber;
    private int routeNumber;
    private String brand;
    private int startYear;
    private double mileage;

    public Bus(String driverName, String busNumber, int routeNumber, String brand, int startYear, double mileage) {
        this.driverName = driverName;
        this.busNumber = busNumber;
        this.routeNumber = routeNumber;
        this.brand = brand;
        this.startYear = startYear;
        this.mileage = mileage;
    }

    public int getRouteNumber() { return routeNumber; }
    public int getStartYear() { return startYear; }
    public double getMileage() { return mileage; }

    public static void printTableHeader() {
        System.out.println(String.format("%-22s | %-12s | %-10s | %-15s | %-12s | %-12s", 
                "Водій", "Номер авто", "Маршрут", "Марка", "Рік випуску", "Пробіг (км)"));
        System.out.println("-".repeat(95));
    }

    public void printRow() {
        System.out.println(String.format("%-22s | %-12s | %-10d | %-15s | %-12d | %-12.1f", 
                driverName, busNumber, routeNumber, brand, startYear, mileage));
    }
}

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Bus[] buses = new Bus[5];
        buses[0] = new Bus("Іваненко І.І.", "АА1234ВВ", 10, "Mercedes", 2015, 120000.5);
        buses[1] = new Bus("Петренко П.П.", "ВС5678АХ", 25, "Bogdan", 2011, 350000.0);
        buses[2] = new Bus("Сидоренко С.С.", "КА9012СЕ", 10, "MAN", 2020, 65000.0);
        buses[3] = new Bus("Коваленко К.К.", "ВХ3456ОО", 15, "Volvo", 2018, 95000.0);
        buses[4] = new Bus("Шевченко Т.Г.", "АМ7890КМ", 25, "Mercedes", 2008, 480000.0);

        System.out.println("=== БАЗА ДАНИХ АВТОПАРКУ ===");
        printBuses(buses);

        int searchRoute = 0;
        while (true) {
            try {
                System.out.print("\nВведіть номер маршруту для пошуку автобусів: ");
                searchRoute = scanner.nextInt();

                if (searchRoute <= 0) {
                    throw new Exception("Номер маршруту не може бути від'ємним або дорівнювати нулю.");
                }
                break;
                
            } catch (InputMismatchException e) {
                System.out.println("Помилка типу даних! Ви ввели текст або символи замість цілого числа. Спробуйте ще раз.");
                scanner.nextLine();
            } catch (Exception e) {
                System.out.println("Помилка логіки: " + e.getMessage() + " Спробуйте ще раз.");
                scanner.nextLine();
            }
        }

        System.out.println("\n>>> РЕЗУЛЬТАТ: Автобуси на маршруті №" + searchRoute);
        boolean foundRoute = false;
        Bus.printTableHeader();
        for (Bus bus : buses) {
            if (bus.getRouteNumber() == searchRoute) {
                bus.printRow();
                foundRoute = true;
            }
        }
        if (!foundRoute) {
            System.out.println("-> Дані за заданим критерієм відсутні.");
        }

        System.out.println("\n>>> РЕЗУЛЬТАТ: Автобуси, які в експлуатації більше 10 років");
        int currentYear = Year.now().getValue();
        boolean foundAge = false;
        Bus.printTableHeader();
        for (Bus bus : buses) {
            if ((currentYear - bus.getStartYear()) > 10) {
                bus.printRow();
                foundAge = true;
            }
        }
        if (!foundAge) {
            System.out.println("-> Дані за заданим критерієм відсутні.");
        }

        System.out.println("\n>>> РЕЗУЛЬТАТ: Автобуси з пробігом більше 100 000 км");
        boolean foundMileage = false;
        Bus.printTableHeader();
        for (Bus bus : buses) {
            if (bus.getMileage() > 100000.0) {
                bus.printRow();
                foundMileage = true;
            }
        }
        if (!foundMileage) {
            System.out.println("-> Дані за заданим критерієм відсутні.");
        }

        scanner.close();
    }

    public static void printBuses(Bus[] buses) {
        Bus.printTableHeader();
        for (Bus bus : buses) {
            bus.printRow();
        }
    }
}