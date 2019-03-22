package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] strings = scanner.nextLine().trim().split("\\s");
        String A;
        String B;
        if (strings[0].length() > strings[1].length()) {
            A = strings[0];
            B = strings[1];
        } else {
            B = strings[0];
            A = strings[1];
        }
        long charSum = calculateCharSum(A, B);
        System.out.println(charSum);
    }
    private static long calculateCharSum(String A, String B) {
        long charSum = 0;
        for (int i = 0; i < A.length(); i++) {
            if (i < B.length()) {
                charSum += (A.charAt(i) * B.charAt(i));
            } else {
                charSum += A.charAt(i);
            }
        }

        return charSum;
    }
}
