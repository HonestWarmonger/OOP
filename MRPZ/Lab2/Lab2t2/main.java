import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String originalText = "Риби це холоднокровні хребетні тварини. Температура їх тіла залежить від температури навколишнього середовища.";
        
        System.out.println("--- Вхідні дані ---");
        System.out.println("Текст: " + originalText);

        System.out.print("Введіть позицію k: ");
        int k = scanner.nextInt();
        
        System.out.print("Введіть символ для заміни: ");
        char replacementChar = scanner.next().charAt(0);

        String[] parts = originalText.split("(?<=[^\\p{L}\\p{Nd}])|(?=[^\\p{L}\\p{Nd}])");
        StringBuilder resultText = new StringBuilder();

        for (String part : parts) {

            if (part.matches("[\\p{L}\\p{Nd}]+")) {
                if (part.length() >= k) {
                    char[] chars = part.toCharArray();
                    chars[k - 1] = replacementChar;
                    resultText.append(new String(chars));
                } else {
                    resultText.append(part);
                }
            } else {
                resultText.append(part);
            }
        }

        System.out.println("\n--- Результат обробки ---");
        System.out.println(resultText.toString());
    }
}