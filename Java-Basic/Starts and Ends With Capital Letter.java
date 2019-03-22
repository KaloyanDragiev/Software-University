package com.company;

import java.util.Scanner;
import java.util.regex.*;

public class Main {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String[] text = input.nextLine().split("[ ]+");
        String pattern1 = "[A-Z][A-Z]";
        String pattern2 = "[A-Z][a-z]+[A-Z]";
        String pattern3 = "[A-Z]+[a-z]+[A-Z]+[a-z]+[A-Z]";
        Pattern pattern = Pattern.compile(pattern1);
        for (int i = 0; i < text.length; i++) {
            String currentElement = text[i];
            Matcher matcher = pattern.matcher(currentElement);
            while (matcher.find()) {
                System.out.print(matcher.group() + " ");
            }
        }
        pattern = Pattern.compile(pattern2);
        for (int i = 0; i < text.length; i++) {
            String currentElement = text[i];
            Matcher matcher = pattern.matcher(currentElement);
            if (matcher.find()) {
                if (currentElement.length() == matcher.group().length()) {
                    System.out.print(matcher.group() + " ");
                }
            }
        }
        pattern = Pattern.compile(pattern3);
        for (int i = 0; i < text.length; i++) {
            String currentElement = text[i];
            Matcher matcher = pattern.matcher(currentElement);
            while (matcher.find()) {
                System.out.print(matcher.group() + " ");
            }
        }
    }
}
