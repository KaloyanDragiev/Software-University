package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] strArr = scanner.nextLine().trim().split("\\s");
        for (int i = 0; i < strArr.length; i++) {
            String currentStr = strArr[i];
            System.out.print(currentStr);

            for (int j = i + 1; j < strArr.length; j++) {
                String compareStr = strArr[j];
                if (compareStr.equals(currentStr)) {
                    System.out.print(" " + compareStr);
                    i++;
                }
            }
            System.out.println();
        }
    }
}
