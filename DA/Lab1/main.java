public class Main {

    static class Node {
        String data;
        Node next;
        Node prev;

        Node(String data) {
            this.data = data;
        }
    }

    static class DoublyLinkedList {
        private Node head;
        private Node tail;

        public boolean isEmpty() {
            return head == null;
        }

        private boolean isValidHex(String value) {
            try {
                int number = Integer.parseInt(value, 16);
                return number > 0;
            } catch (NumberFormatException e) {
                return false;
            }
        }

        public boolean add(String data) {
            if (!isValidHex(data)) {
                System.out.println("Помилка: " + data + " не є додатнім шістнадцятковим числом.");
                return false;
            }

            Node newNode = new Node(data);

            if (isEmpty()) {
                head = newNode;
                tail = newNode;
            } else {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }

            return true;
        }

        public String removeFirst() {
            if (isEmpty()) {
                throw new RuntimeException("Список порожній. Видалення неможливе.");
            }

            String deletedData = head.data;

            if (head == tail) {
                head = null;
                tail = null;
            } else {
                head = head.next;
                head.prev = null;
            }

            return deletedData;
        }

        public String removeLast() {
            if (isEmpty()) {
                throw new RuntimeException("Список порожній. Видалення неможливе.");
            }

            String deletedData = tail.data;

            if (head == tail) {
                head = null;
                tail = null;
            } else {
                tail = tail.prev;
                tail.next = null;
            }

            return deletedData;
        }

        public void printForward() {
            if (isEmpty()) {
                System.out.println("Список порожній.");
                return;
            }

            Node current = head;
            System.out.print("Вміст списку: ");
            while (current != null) {
                System.out.print(current.data + " ");
                current = current.next;
            }
            System.out.println();
        }
    }

    public static void main(String[] args) {
        DoublyLinkedList list = new DoublyLinkedList();

        System.out.println("Додаємо елементи до списку:");
        list.add("A");
        list.add("1F");
        list.add("2B");
        list.add("10");
        list.add("FF");

        list.printForward();

        System.out.println("\nВидаляємо декілька елементів:");
        System.out.println("Видалено перший елемент: " + list.removeFirst());
        System.out.println("Видалено останній елемент: " + list.removeLast());

        list.printForward();
    }
}