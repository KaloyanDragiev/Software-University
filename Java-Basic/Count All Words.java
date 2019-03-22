package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] inputArr = scanner.nextLine().trim().split("[^a-zA-Z]+");
        System.out.println(inputArr.length);
    }
}
