import java.io.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class FileInPlaceEditor {

    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);

        System.out.print("Введіть повний шлях до текстового файлу для редагування: ");
        String filePath = console.nextLine();
        File file = new File(filePath);

        if (!file.exists()) {
            System.out.println("Помилка: Файл не знайдено за вказаним шляхом.");
            return;
        }

        List<String> lines = new ArrayList<>();

        try (BufferedReader reader = new BufferedReader(new FileReader(file))) {
            System.out.println("Читання файлу: " + file.getName());
            String line;
            while ((line = reader.readLine()) != null) {
                lines.add(swapFirstAndLastWords(line));
            }
            System.out.println("Файл успішно зчитано та оброблено в пам'яті.");
        } catch (IOException e) {
            System.err.println("Помилка при читанні: " + e.getMessage());
            return;
        }

        try (BufferedWriter writer = new BufferedWriter(new FileWriter(file))) {
            System.out.println("Запис змін у файл...");
            for (int i = 0; i < lines.size(); i++) {
                writer.write(lines.get(i));
                writer.newLine();
            }
            System.out.println("Зміни успішно збережені безпосередньо у файлі!");
        } catch (IOException e) {
            System.err.println("Помилка при записі: " + e.getMessage());
        } finally {
            console.close();
        }
    }

    private static String swapFirstAndLastWords(String line) {
        if (line == null || line.trim().isEmpty()) {
            return line;
        }

        String[] words = line.trim().split("\\s+");

        if (words.length < 2) {
            return line;
        }

        String first = words[0];
        String last = words[words.length - 1];
        
        words[0] = last;
        words[words.length - 1] = first;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < words.length; i++) {
            sb.append(words[i]);
            if (i < words.length - 1) {
                sb.append(" ");
            }
        }
        return sb.toString();
    }
}