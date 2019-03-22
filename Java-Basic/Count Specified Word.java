package com.company;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String Stack = scanner.nextLine().toLowerCase();
        String needle = scanner.next().toLowerCase();
        System.out.println(Stream.of(Stack.trim().split("[^a-z]")).filter(s -> s.equals(needle)).count());
    }
}
