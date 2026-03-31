public class Main {
    public static void main(String[] args) {
        Thread t1 = createThread("1", 1000);
        Thread t2 = createThread("2", 2000);
        Thread t3 = createThread("3", 3000);
        t1.start();
        t2.start();
        t3.start();
        try {
            t1.join();
            t2.join();
            t3.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        
    }

    private static Thread createThread(String number, int delay) {
        return new Thread(() -> {
            try {
                Thread.sleep(delay);
                System.out.println(number);
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
            }
        });
    }
}