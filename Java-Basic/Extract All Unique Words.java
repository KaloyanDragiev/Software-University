package com.company;

import sun.reflect.generics.tree.Tree;

import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine().toLowerCase();

        Pattern pattern = Pattern.compile("[a-zA-Z]+");
        Matcher matcher = pattern.matcher(input);

        TreeSet<String> results = new TreeSet<>();
        while (matcher.find()) {
            results.add(matcher.group());
        }
        for (String result : results) {
            System.out.print(result + " ");
        }
    }
}
