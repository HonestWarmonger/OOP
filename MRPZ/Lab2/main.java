import java.util.Random;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        System.out.print("Введіть кількість цифр у числі: ");
        int length = scanner.nextInt();

        if (length < 2) {
            System.out.println("Довжина має бути мінімум 2 для обміну цифр.");
            return;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < length; i++) {
            int digit = (i == 0) ? random.nextInt(9) + 1 : random.nextInt(10);
            sb.append(digit);
        }

        String originalNumber = sb.toString();
        System.out.println("Початкове число: " + originalNumber);

        StringBuilder processedDigits = new StringBuilder();
        for (char c : originalNumber.toCharArray()) {
            int digit = Character.getNumericValue(c);

            if (digit % 2 == 0) {
                int newDigit = (digit == 0) ? 9 : digit - 1;
                processedDigits.append(newDigit);
            } else {
                processedDigits.append(digit);
            }
        }

        char first = processedDigits.charAt(0);
        char second = processedDigits.charAt(1);
        
        processedDigits.setCharAt(0, second);
        processedDigits.setCharAt(1, first);

        System.out.println("Результат обробки: " + processedDigits.toString());
    }
}