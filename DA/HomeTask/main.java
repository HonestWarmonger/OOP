import java.util.Scanner;

public class LUPDecomposition {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("--- Метод LUP-розкладання ---");
        System.out.print("Введіть розмірність матриці (n): ");
        int n = scanner.nextInt();

        double[][] A = new double[n][n];
        double[] b = new double[n];

        System.out.println("Введіть коефіцієнти матриці A (по рядках):");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                A[i][j] = scanner.nextDouble();
            }
        }

        System.out.println("Введіть елементи вектора правих частин (b):");
        for (int i = 0; i < n; i++) {
            b[i] = scanner.nextDouble();
        }

        printSystem(A, b);

        double[][] L = new double[n][n];
        double[][] U = new double[n][n];
        double[][] P = new double[n][n];
        
        for (int i = 0; i < n; i++) {
            P[i][i] = 1.0;
            L[i][i] = 1.0;
        }

        double[][] work = new double[n][n];
        for (int i = 0; i < n; i++) {
            System.arraycopy(A[i], 0, work[i], 0, n);
        }

        try {
            decomposeLUP(work, P, n);
        } catch (RuntimeException e) {
            System.out.println("Помилка: " + e.getMessage());
            return;
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (i > j) {
                    L[i][j] = work[i][j];
                } else {
                    U[i][j] = work[i][j];
                }
            }
        }

        System.out.println("\nМатриця перестановок (P):");
        printMatrix(P);

        System.out.println("Нижня трикутна матриця (L):");
        printMatrix(L);

        System.out.println("Верхня трикутна матриця (U):");
        printMatrix(U);

        double[] x = solveLUP(L, U, P, b, n);

        System.out.println("Розв'язок системи (вектор x):");
        for (int i = 0; i < n; i++) {
            System.out.printf("x[%d] = %8.4f\n", i + 1, x[i]);
        }

        scanner.close();
    }

    private static void decomposeLUP(double[][] work, double[][] P, int n) {
        for (int k = 0; k < n; k++) {
            double maxVal = 0.0;
            int kPrime = k;

            for (int i = k; i < n; i++) {
                if (Math.abs(work[i][k]) > maxVal) {
                    maxVal = Math.abs(work[i][k]);
                    kPrime = i;
                }
            }
            
            if (maxVal < 1e-10) {
                throw new RuntimeException("Матриця є виродженою. Система не має єдиного розв'язку.");
            }

            double[] tempWork = work[k];
            work[k] = work[kPrime];
            work[kPrime] = tempWork;

            double[] tempP = P[k];
            P[k] = P[kPrime];
            P[kPrime] = tempP;

            for (int i = k + 1; i < n; i++) {
                work[i][k] /= work[k][k];
                for (int j = k + 1; j < n; j++) {
                    work[i][j] -= work[i][k] * work[k][j];
                }
            }
        }
    }

    private static double[] solveLUP(double[][] L, double[][] U, double[][] P, double[] b, int n) {
        double[] Pb = new double[n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Pb[i] += P[i][j] * b[j];
            }
        }

        double[] y = new double[n];
        for (int i = 0; i < n; i++) {
            y[i] = Pb[i];
            for (int j = 0; j < i; j++) {
                y[i] -= L[i][j] * y[j];
            }
            y[i] /= L[i][i];
        }

        double[] x = new double[n];
        for (int i = n - 1; i >= 0; i--) {
            x[i] = y[i];
            for (int j = i + 1; j < n; j++) {
                x[i] -= U[i][j] * x[j];
            }
            x[i] /= U[i][i];
        }

        return x;
    }

    private static void printSystem(double[][] A, double[] b) {
        System.out.println("\nЗадана СЛАР:");
        for (int i = 0; i < A.length; i++) {
            for (int j = 0; j < A[i].length; j++) {
                System.out.printf("%6.1f * x%d ", A[i][j], (j + 1));
                if (j < A[i].length - 1) {
                    System.out.print(A[i][j+1] >= 0 ? " + " : " - ");
                }
            }
            System.out.printf(" = %6.1f\n", b[i]);
        }
    }

    private static void printMatrix(double[][] matrix) {
        for (double[] row : matrix) {
            for (double val : row) {
                System.out.printf("%9.4f ", val);
            }
            System.out.println();
        }
        System.out.println();
    }
}