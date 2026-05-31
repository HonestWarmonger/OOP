import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {
    enum State {
        Q0, Q1, Q2, Q3, Q4, ERROR
    }

    public static void main(String[] args) throws IOException {
        String fileName = "words.txt";
        List<String> words = Arrays.asList(
                "#123%#", 
                "#*#", 
                "#45ABC#", 
                "123%#", 
                "#123#", 
                "#A#", 
                "#12AB*#"
        );
        Files.write(Paths.get(fileName), words);

        System.out.println("Завдання першого рівня:");
        Pattern pattern1 = Pattern.compile("^#[0-9]*(%|\\*|[A-Z]+)#$");
        
        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = reader.readLine()) != null) {
                Matcher matcher = pattern1.matcher(line);
                if (matcher.matches()) {
                    System.out.println(line);
                }
            }
        }

        System.out.println("\nЗавдання другого рівня:");
        String regex2 = "\\d+(%|\\*|([A-Z])+)#";
        
        Scanner scanner = new Scanner(System.in);
        System.out.print("Введіть рядок: ");
        String input = scanner.nextLine();

        State state = State.Q0;
        for (int i = 0; i < input.length(); i++) {
            char c = input.charAt(i);
            switch (state) {
                case Q0:
                    if (Character.isDigit(c)) {
                        state = State.Q1;
                    } else {
                        state = State.ERROR;
                    }
                    break;
                case Q1:
                    if (Character.isDigit(c)) {
                        state = State.Q1;
                    } else if (c == '%' || c == '*') {
                        state = State.Q2;
                    } else if (c >= 'A' && c <= 'Z') {
                        state = State.Q3;
                    } else {
                        state = State.ERROR;
                    }
                    break;
                case Q2:
                    if (c == '#') {
                        state = State.Q4;
                    } else {
                        state = State.ERROR;
                    }
                    break;
                case Q3:
                    if (c >= 'A' && c <= 'Z') {
                        state = State.Q3;
                    } else if (c == '#') {
                        state = State.Q4;
                    } else {
                        state = State.ERROR;
                    }
                    break;
                case Q4:
                    state = State.ERROR;
                    break;
                default:
                    state = State.ERROR;
                    break;
            }
        }

        boolean automatonMatches = (state == State.Q4);
        boolean regexMatches = Pattern.matches(regex2, input);

        if (automatonMatches && regexMatches) {
            System.out.println("Рядок підтверджено автоматом та виразом " + regex2);
        } else {
            System.out.println("Рядок не відповідає заданій синтаксичній структурі.");
        }
        
        scanner.close();
    }
}