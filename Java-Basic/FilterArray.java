package com.company;

import java.util.Arrays;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String[]words = console.nextLine().split("\\s+");

        Arrays.stream(words)
                .filter(w -> w.length() > 3)
                .forEach(w -> System.out.printf("%s ", w));
    }
}
