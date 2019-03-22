package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer numberToConvert = scanner.nextInt();
        System.out.print(Integer.toString(numberToConvert, 7));
    }
}
