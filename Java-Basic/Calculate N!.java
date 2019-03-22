package com.company;

import java.math.BigInteger;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        long bigNum = scanner.nextLong();
        System.out.println(calculateFactorial(bigNum));
    }

    private static long calculateFactorial(long num) {
        if (num == 1 || num == 0) {
            return 1;
        }
        return num * calculateFactorial(num - 1);
    }
}
