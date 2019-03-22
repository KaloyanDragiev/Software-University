package com.company;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String list1 = scanner.nextLine();
        String list2 = scanner.nextLine();

        List<Character> result = new ArrayList<>();
        for (int i = 0; i < list1.length(); i++) {
            char currentChar = list1.charAt(i);
            if(currentChar != ' ') {
                result.add(currentChar);
            }
        }
        for (int i = 0; i < list2.length(); i++) {
            char currentChar = list2.charAt(i);
            if(currentChar != ' ' && !list1.contains("" + currentChar)) {
                result.add(currentChar);
            }
        }

        for (Character ch : result) {
            System.out.print(ch + " ");
        }
    }
}
