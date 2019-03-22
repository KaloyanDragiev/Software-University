package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String numberToConvert = scanner.next();
        Integer decimalRepresentation = Integer.valueOf(numberToConvert, 7);
        System.out.println(decimalRepresentation);
    }
}
