import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

interface Searchable {
    void searchByAuthor(String author);
    void searchByStyle(String style);
}

class ArtExhibition implements Searchable {
    private String location;
    private String time;
    private List<Painting> paintings;

    public ArtExhibition(String location, String time) {
        this.location = location;
        this.time = time;
        this.paintings = new ArrayList<>();
        System.out.println("[ЛОГ] Створено об'єкт виставки в місті/місці: " + location + " (Час: " + time + ")");
    }

    class Painting {
        private String title;
        private String author;
        private String style; 

        public Painting(String title, String author, String style) {
            this.title = title;
            this.author = author;
            this.style = style;
            System.out.println("[ЛОГ] Внутрішній клас: Створено об'єкт картини \"" + title + "\"");
        }

        public String getTitle() { return title; }
        public String getAuthor() { return author; }
        public String getStyle() { return style; }

        public void displayPaintingInfo() {
            System.out.println("  -> \"" + title + "\" | Автор: " + author + " | Напрям: " + style + 
                               " [Експонується за адресою: " + location + "]");
        }
    }

    public void addPainting(String title, String author, String style) {
        Painting newPainting = new Painting(title, author, style);
        this.paintings.add(newPainting);
        System.out.println("[ЛОГ] Картину успішно додано до наповнення виставки.");
    }

    public void displayExhibitionDetails() {
        System.out.println("\n==================================================");
        System.out.println("СТРУКТУРОВАНА ІНФОРМАЦІЯ ПРО ХУДОЖНЮ ВИСТАВКУ");
        System.out.println("==================================================");
        System.out.println("Місце проведення: " + location);
        System.out.println("Час проведення:  " + time);
        System.out.println("Наповнення виставки (список картин):");
        
        if (paintings.isEmpty()) {
            System.out.println("   (Виставка наразі порожня)");
        } else {
            for (Painting p : paintings) {
                p.displayPaintingInfo();
            }
        }
        System.out.println("==================================================\n");
    }

    @Override
    public void searchByAuthor(String author) {
        System.out.println("[ЛОГ] Інтерфейс -> Запуск пошуку за автором: \"" + author + "\"");
        boolean found = false;
        for (Painting p : paintings) {
            if (p.getAuthor().equalsIgnoreCase(author)) {
                p.displayPaintingInfo();
                found = true;
            }
        }
        if (!found) {
            System.out.println("Картини автора \"" + author + "\" не знайдено на цій виставці.");
        }
    }

    @Override
    public void searchByStyle(String style) {
        System.out.println("[ЛОГ] Інтерфейс -> Запуск пошуку за напрямом (стилем): \"" + style + "\"");
        boolean found = false;
        for (Painting p : paintings) {
            if (p.getStyle().equalsIgnoreCase(style)) {
                p.displayPaintingInfo();
                found = true;
            }
        }
        if (!found) {
            System.out.println("Картини у напрямі \"" + style + "\" не знайдено на цій виставці.");
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("=== Введення даних для Художньої Виставки ===");
        System.out.print("Введіть місце проведення виставки: ");
        String location = scanner.nextLine();
        System.out.print("Введіть час проведення виставки: ");
        String time = scanner.nextLine();

        ArtExhibition exhibition = new ArtExhibition(location, time);

        System.out.print("\nСкільки картин ви бажаєте додати до виставки? ");
        int count = scanner.nextInt();
        scanner.nextLine();

        for (int i = 1; i <= count; i++) {
            System.out.println("\n--- Введення даних картини №" + i + " ---");
            System.out.print("Назва картини: ");
            String title = scanner.nextLine();
            System.out.print("Автор картини: ");
            String author = scanner.nextLine();
            System.out.print("Напрям: ");
            String style = scanner.nextLine();

            exhibition.addPainting(title, author, style);
        }

        exhibition.displayExhibitionDetails();

        Searchable searchEngine = exhibition;

        System.out.println("=== Демонстрація пошуку через інтерфейс ===");
        System.out.print("Введіть ім'я автора для пошуку: ");
        String searchAuthor = scanner.nextLine();
        searchEngine.searchByAuthor(searchAuthor);

        System.out.print("\nВведіть напрям мистецтва для пошуку: ");
        String searchStyle = scanner.nextLine();
        searchEngine.searchByStyle(searchStyle);

        System.out.println("\n[ЛОГ] Роботу програми успішно завершено.");
        scanner.close();
    }
}