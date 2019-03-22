package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int a = scanner.nextInt();
        double b = scanner.nextDouble();
        double c = scanner.nextDouble();
        String hex = Integer.toHexString(a).toUpperCase();
        String bin = Integer.toBinaryString(a);
        System.out.printf("|%-10s|%010d|%10.2f|%-10.3f|", hex,Integer.parseInt(bin), b, c);
    }
}
