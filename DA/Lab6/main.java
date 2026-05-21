import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] sizes = {100, 10000, 1000000};
        long timeFor10k = 0;

        System.out.println("N\tBubbleSort_Time");
        for (int size : sizes) {
            if (size == 1000000) {
                long estimatedTime = timeFor10k * 10000;
                System.out.println(size + "\t" + estimatedTime);
                continue;
            }

            int runs = 5;
            long totalTime = 0;
            
            for (int r = 0; r < runs; r++) {
                double[] arr = generateArray(size);
                long start = System.nanoTime();
                optimizedBubbleSort(arr);
                long end = System.nanoTime();
                totalTime += (end - start);
            }
            long avgTime = totalTime / runs;
            if (size == 10000) {
                timeFor10k = avgTime;
            }
            System.out.println(size + "\t" + avgTime);
        }

        System.out.println("\nN\tLinearSearch_Time\tBinarySearch_Time");
        for (int size : sizes) {
            int runs = 10;
            long totalLinearTime = 0;
            long totalBinaryTime = 0;

            for (int r = 0; r < runs; r++) {
                double[] arr = generateArray(size);
                Arrays.sort(arr);
                double key = arr[(int) (Math.random() * size)];

                long startLinear = System.nanoTime();
                linearSearch(arr, key);
                long endLinear = System.nanoTime();
                totalLinearTime += (endLinear - startLinear);

                long startBinary = System.nanoTime();
                binarySearch(arr, key);
                long endBinary = System.nanoTime();
                totalBinaryTime += (endBinary - startBinary);
            }
            System.out.println(size + "\t" + (totalLinearTime / runs) + "\t\t\t" + (totalBinaryTime / runs));
        }
    }

    public static double[] generateArray(int size) {
        double[] arr = new double[size];
        for (int i = 0; i < size; i++) {
            arr[i] = Math.random() * 100000.0;
        }
        return arr;
    }

    public static void optimizedBubbleSort(double[] arr) {
        int n = arr.length;
        boolean swapped;
        for (int i = 0; i < n - 1; i++) {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++) {
                if (arr[j] > arr[j + 1]) {
                    double temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) {
                break;
            }
        }
    }

    public static int linearSearch(double[] arr, double key) {
        for (int i = 0; i < arr.length; i++) {
            if (arr[i] == key) {
                return i;
            }
        }
        return -1;
    }

    public static int binarySearch(double[] arr, double key) {
        int left = 0;
        int right = arr.length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] == key) {
                return mid;
            }
            if (arr[mid] < key) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return -1;
    }
}