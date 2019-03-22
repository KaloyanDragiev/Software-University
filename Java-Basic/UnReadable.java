import javax.print.DocFlavor;
import java.util.ArrayList;
import java.util.Scanner;

public class UnReadable {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = scanner.nextInt();
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++) {
            numbers[i] = scanner.nextInt();
        }
        ArrayList<String> output = new ArrayList<String>();

        for (int i = 0; i < numbers.length; i++) {
            for (int j = 0; j < numbers.length; j++) {
                for (int k = 0; k < numbers.length; k++) {
                    for (int l = 0; l < numbers.length; l++) {
                        boolean checkIsEqual =  numbers[i] != numbers[j]&&
                                                numbers[i] != numbers[k]&&
                                                numbers[i] != numbers[l]&&
                                                numbers[j] != numbers[k]&&
                                                numbers[j] != numbers[j]&&
                                                numbers[l] != numbers[k];

                        if (checkIsEqual && (""+numbers[i]+numbers[j]).equals
                                            (""+numbers[k]+numbers[l])) {
                            output.add(numbers[i] + "|" + numbers[j] + "=="
                                       + numbers[k] + "|" + numbers[l]);
                            System.out.println("1");
                        }
                    }
                }
            }
        }
        //2 51 1 75 25
        for (String line : output)
        {
            System.out.println(output);
        }
    }
}
